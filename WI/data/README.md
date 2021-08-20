# Wisconsin Data

Only local artifacts are included in the repository.

| Name | ID | Date | Description | Author(s) | References | Type | Local? | Path |
|------|----|------|-------------|-----------|------------|------|--------|------|
| Census block relationship files [(source)](https://www2.census.gov/geo/docs/maps-data/data/rel2020/t10t20/TAB2010_TAB2020_ST55.zip) | `block_relationship` | 2021-08-12 | Mappings between 2010 Census blocks and 2020 Census blocks. | United States Census Bureau | [U.S. Census relationship files](https://www.census.gov/geographies/reference-files/time-series/geo/relationship-files.html) | `table` | ❌ | `tab2010_tab2020_st55_wi.txt` |
| 2020 Census block shapefile [(source)](https://www2.census.gov/geo/tiger/TIGER2020/TABBLOCK20/tl_2020_55_tabblock20.zip) | `block_shapefile` | 2021-08-12 |  | United States Census Bureau | [U.S. Census TIGER/Line shapefiles](https://www.census.gov/geographies/mapping-files/time-series/geo/tiger-line-file.html) | `shapefile_zip` | ❌ | `tl_2020_55_tabblock20` |
| Portal submissions index | `submissions_index_20210819` | 2021-08-19 | Portal submissions | Parker Rule | [PMC Public Comment Portal](https://portal.wisconsin-mapping.org/) | `json` | ✅ | `wi_submissions_index_20210819.json` |
| Annotations database dump | `annotations_20210815` | 2021-08-15 | MongoDB annotations database dump. | MGGG annotators, Maxwell Fan, Parker Rule |  | `json` | ✅ | `WI_dump_20210815.jsonl` |
| Cluster database [(source)](https://drive.google.com/uc?id=1KaFK4rapQHLcfPod2id704iTB3W3xIrE) | `cluster_db_20210809` | 2021-08-09 | Hausdorff distance-based clusters generated on COI submissions. | Parker Edwards, Ari Stern |  | `pickle` | ❌ | `wi_cluster_db_20210809.pkl` |
| Portal submissions | `submissions_20210810` | 2021-08-10 | Portal submissions database dump. | Robbie Veglahn |  | `table` | ✅ | `WICumulativeAug10.csv` |
