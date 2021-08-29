module GeoSemanticClusters
open MathNet.Numerics

type Bin = int
type Document = int

type GeoScore = float
type SemanticScore = float
type ClusteringScore = GeoScore*SemanticScore

type Clustering = Map<Document, Bin>
type ScoreFunction = GeoScore[,] -> SemanticScore[,] -> Clustering -> ClusteringScore
type Proposal = Clustering -> Clustering
type SoftConstraint = Clustering -> float
type AcceptanceFunction = ClusteringScore -> ClusteringScore -> float

let rand = System.Random()

/// <summary>
///     Class definining the Markov Chain over clusterings.
/// </summary>
/// <param name="proposal"> Propsal function for the chain. </param> 
/// <param name="score"> Score function for the chain. </param>
/// <param name="geoDistance"> Matrix of pairwise geographic distances between documents. </param>
/// <param name="semanticSim"> Matrix of pairwise semantic similarites between documents. </param>
/// <param name="accept"> Acceptance function for the chain. </param>
/// <param name="softConstraints"> (optional) Soft constraint function for chain. </param>
type MarkovChain(proposal: Proposal, score: ScoreFunction, geoDistance: GeoScore[,], semanticSim: SemanticScore[,], accept: AcceptanceFunction, ?softConstraints: SoftConstraint) = 
    member this.ProposalFunction = proposal
    member this.ScoreFunction = score geoDistance semanticSim
    member this.SoftConstraints = defaultArg softConstraints (fun _ -> 1.)
    member this.AcceptanceFunction = accept

    /// <summary>
    ///     Get next step in the Markov Chain
    /// </summary>
    /// <param name="currentState"> The current state of the chain. </param> 
    /// <param name="currentScore"> (optional) The score for the current state of the chain. </param>
    /// <returns> Next state of the chain. </returns>
    member this.StateTransistionStep (currentState: Clustering, ?currentScore: ClusteringScore) =
        let curScore = defaultArg currentScore (this.ScoreFunction currentState)
        let proposedState = this.ProposalFunction currentState
        let newScore = this.ScoreFunction proposedState
        let softConstraintsProposed = this.SoftConstraints proposedState
        let acceptProb = this.AcceptanceFunction curScore newScore

        match rand.NextDouble() < acceptProb * softConstraintsProposed with
        | true -> proposedState, newScore
        | _ -> currentState, curScore

/// <summary>
///     Propose new cluster of documents
/// </summary>
/// <param name="bins"> List of the bin indetifiers for the clustering </param>
/// <param name="documents"> List of the document identifiers </param> 
/// <param name="currentState"> The current state of the chain </param>
/// <returns> Propsed new state of the chain </returns>
let FlipProposal (bins: Bin list) (documents: Document list) (currentState: Clustering) =
    let doc = documents.[rand.Next(documents.Length)]
    let newBin = bins.[rand.Next(bins.Length)]
    currentState.Add(doc, newBin)

/// <summary>
///     Computer average intra-cluster scores.
/// </summary>
/// <param name="bins"> List of the bin indetifiers for the clustering </param>
/// <param name="geoScoreMatrix"> Matrix of pairwise geographic distances between documents. </param>
/// <param name="semanticScoreMatrix"> Matrix of pairwise semantic similarites between documents. </param>
/// <param name="currentState"> The current state of the chain </param>
/// <returns> Tuple of average intra-cluster metrics in currently clustering. </returns>
let AvgIntraCluster (bins: Bin list) (geoScoreMatrix: GeoScore[,])
                    (semanticScoreMatrix: SemanticScore[,]) (currentState: Clustering) =
    let clusters = List.map (fun b -> currentState |> Map.filter (fun d c -> c = b) |> Map.toList
                                                   |> List.map fst) bins
    let docPairs = clusters |> List.map List.pairwise |> List.fold List.append []

    let geoScore = docPairs |> List.fold (fun acc (d0, d1) -> acc + geoScoreMatrix.[d0,d1]) 0.
                            |> (/) <| float docPairs.Length
    let semanticScore = docPairs |> List.fold (fun acc (d0, d1) -> acc + semanticScoreMatrix.[d0,d1]) 0.
                                 |> (/) <| float docPairs.Length

    geoScore, semanticScore

/// <summary>
///     Soft constraint enforcing cluster magnitudes above a given threshold.
/// </summary>
/// <param name="bins"> List of the bin indetifiers for the clustering </param>
/// <param name="idealClusterSize"> At what size threshold should clustering start to be penalized 
/// for small clusters. </param>
/// <param name="cluster"> The current state of the chain </param>
/// <returns> Probability of acceptance given the sizes of the clusters </returns>
let MinClusterSizeSoftConstraint (bins: Bin list) (idealClusterSize: int) (cluster: Clustering) =
    let minClusterLength = List.map (fun b -> cluster |> Map.filter (fun d c -> c = b) |> Map.toList
                                                      |> List.map fst |> List.length) bins |> List.min

    match minClusterLength >= idealClusterSize with
    | true -> 1.
    | _ -> float minClusterLength / float idealClusterSize


/// <summary>
///     Acceptance function for chain based on geographic and semantic scores.
/// </summary>
/// <param name="beta"> List of the bin indetifiers for the clustering </param>
/// <param name="currentGeoScore"> The geographic score for the current clustering </param>
/// <param name="currentSemanticScore"> The semantic score for the current clustering </param>
/// <param name="proposedGeoScore"> The geographic score for the proposed clustering </param>
/// <param name="proposedSemanticScore"> The semantic score for the proposed clustering </param>
/// <returns> Probability of acceptance given the scores of the clustering.  1 if both improve.  
///  Otherwise accept probabilisticly based on the score that got the most worse.</returns>
let GeoSemAcceptanceProb (beta: float) ((currentGeoScore, currentSemanticScore): ClusteringScore) 
                         ((proposedGeoScore, proposedSemanticScore): ClusteringScore) =
    match proposedGeoScore <= currentGeoScore, proposedSemanticScore >= currentSemanticScore with
    | true, true -> 1.
    | _ -> let m = min (currentGeoScore / proposedGeoScore) (proposedSemanticScore / currentSemanticScore)
           Constants.E ** (- beta / m)

/// <summary>
///     Acceptance function for chain based only on semantic scores.
/// </summary>
/// <param name="beta"> List of the bin indetifiers for the clustering </param>
/// <param name="currentSemanticScore"> The semantic score for the current clustering </param>
/// <param name="proposedSemanticScore"> The semantic score for the proposed clustering </param>
/// <returns> Probability of acceptance given the scores of the clustering.  1 if improved.  
///  Otherwise accept probabilisticly based on how much worse the score got.</returns>
let SemAcceptanceProb (beta: float) ((_, currentSemanticScore): ClusteringScore) 
                      ((_, proposedSemanticScore): ClusteringScore) =
    match proposedSemanticScore >= currentSemanticScore with
    | true -> 1.
    | _ -> let m = proposedSemanticScore / currentSemanticScore
           Constants.E ** (- beta / m)

/// <summary>
///     Acceptance function for chain based only on geographic scores.
/// </summary>
/// <param name="beta"> List of the bin indetifiers for the clustering </param>
/// <param name="currentGeoScore"> The geographic score for the current clustering </param>
/// <param name="proposedGeoScore"> The geographic score for the proposed clustering </param>
/// <returns> Probability of acceptance given the scores of the clustering.  1 if improved.  
///  Otherwise accept probabilisticly based on how much worse the score got.</returns>
let GeoAcceptanceProb (beta: float) ((currentGeoScore, _): ClusteringScore) 
                      ((proposedGeoScore, _): ClusteringScore) =
    match proposedGeoScore <= currentGeoScore with
    | true -> 1.
    | _ -> let m = currentGeoScore / proposedGeoScore
           Constants.E ** (- beta / m)