# Ohio Data

Only local artifacts are included in the repository.

| Name | ID | Date | Description | Author(s) | References | Type | Local? | Path |
|------|----|------|-------------|-----------|------------|------|--------|------|
| Census block relationship files [(source)](https://www2.census.gov/geo/docs/maps-data/data/rel2020/t10t20/TAB2010_TAB2020_ST39.zip) | `block_relationship` | 2021-08-12 | Mappings between 2010 Census blocks and 2020 Census blocks. | United States Census Bureau | [U.S. Census relationship files](https://www.census.gov/geographies/reference-files/time-series/geo/relationship-files.html) | `table` | ❌ | `tab2010_tab2020_st39_oh.txt` |
| 2020 Census block shapefile [(source)](https://www2.census.gov/geo/tiger/TIGER2020/TABBLOCK20/tl_2020_39_tabblock20.zip) | `block_2020_shapefile` | 2021-08-12 |  | United States Census Bureau | [U.S. Census TIGER/Line shapefiles](https://www.census.gov/geographies/mapping-files/time-series/geo/tiger-line-file.html) | `shapefile_zip` | ❌ | `tl_2020_39_tabblock20` |
| Portal submissions index | `submissions_index_20210819` | 2021-08-19 | Portal submissions | Parker Rule | [OCRC Public Comment Portal](https://portal.ohio-mapping.org/) | `json` | ✅ | `oh_submissions_index_20210819.json` |
| Annotations database dump | `annotations_20210815` | 2021-08-15 | MongoDB annotations database dump. | MGGG annotators, Maxwell Fan, Parker Rule |  | `json` | ✅ | `OH_dump_20210815.jsonl` |
| Cluster database [(source)](https://drive.google.com/uc?id=11gJ2odN1rBA9uXGxmmvJuWQXEKiH2ZSe) | `cluster_db_20210809` | 2021-08-09 | Hausdorff distance-based clusters generated on COI submissions. | Parker Edwards, Ari Stern |  | `pickle` | ❌ | `oh_cluster_db_20210809.pkl` |
| Portal submissions | `submissions_20210810` | 2021-08-10 | Portal submissions database dump. | Robbie Veglahn |  | `table` | ✅ | `OHCumulativeAug10.csv` |
| 2010 Census block group shapefile [(source)](https://www2.census.gov/geo/tiger/TIGER2010/BG/2010/tl_2010_39_bg10.zip) | `bg_2010_shapefile` | 2010-12-21 |  | United States Census Bureau | [U.S. Census TIGER/Line shapefiles](https://www.census.gov/geographies/mapping-files/time-series/geo/tiger-line-file.html) | `shapefile_zip` | ❌ | `tl_2010_39_bg10` |
| 2010 block group dual graph | `bg_2010_graph` | 2021-08-24 | Generated with GerryChain from `tl_2010_39_bg10` shapefile. | Parker Rule |  | `json` | ✅ | `tl_2010_39_bg10.json` |
| 2020 Census block group shapefile [(source)](https://www2.census.gov/geo/tiger/TIGER2020/BG/tl_2020_39_bg.zip) | `bg_2020_shapefile` | 2021-02-01 |  | United States Census Bureau | [U.S. Census TIGER/Line shapefiles](https://www.census.gov/geographies/mapping-files/time-series/geo/tiger-line-file.html) | `shapefile_zip` | ❌ | `tl_2020_39_bg` |
| 2020 Census VTD shapefile [(source)](https://www2.census.gov/geo/tiger/TIGER2020PL/STATE/39_OHIO/39/tl_2020_39_vtd20.zip) | `vtd_shapefile_2020` | 2021-02-01 |  | United States Census Bureau | [U.S. Census TIGER/Line shapefiles](https://www.census.gov/geographies/mapping-files/time-series/geo/tiger-line-file.html) | `shapefile_zip` | ❌ | `tl_2020_39_vtd20` |
| 2010 Census VTD dual graph | `vtd_graph_2020` | 2021-08-25 | Generated with GerryChain from `tl_2020_39_vtd20` shapefile. | Parker Rule |  | `json` | ✅ | `tl_2020_39_vtd20.json` |
| Portal submissions | `submissions_20210825` | 2021-08-25 | Portal submissions database dump. | Parker Rule |  | `table` | ✅ | `oh_submissions_20210825.csv` |
| Portal submissions | `submissions_20210827` | 2021-08-27 | Portal submissions database dump. | Parker Rule |  | `table` | ✅ | `oh_submissions_20210827.csv` |
| Cluster database | `cluster_db_20210825` | 2021-08-25 | Hausdorff distance-based clusters generated on COI submissions. | Parker Rule |  | `pickle` | ✅ | `oh_cluster_db_20210825.pkl` |
| Cluster database | `cluster_db_20210827` | 2021-08-27 | Hausdorff distance-based clusters generated on COI submissions. | Parker Rule |  | `pickle` | ✅ | `oh_cluster_db_20210827.pkl` |
| 2018 precinct shapefile [(source)](https://raw.githubusercontent.com/mggg-states/OH-shapefiles/e523226fb9d90c589b698b9e8720c2e4c3b22fc0/OH_precincts.zip) | `precinct_2018_shapefile` | 2020-06-26 |  | MGGG | [mggg-states repository](https://github.com/mggg-states/OH-shapefiles) | `shapefile_zip` | ❌ | `OH_precincts` |
| 2020 Census block dual graph | `block_2020_graph` | 2021-08-27 | Generated with GerryChain from `tl_2020_39_tabblock20` shapefile. | Parker Rule |  | `json` | ✅ | `tl_2020_39_tabblock20.json` |
| Crosswalk between 2020 VTDs and 2020 Census blocks | `vtd_2020_to_block_2020` | 2021-08-26 | Generated with maup. | Parker Rule |  | `json` | ✅ | `oh_2020_vtds_to_2020_blocks.json` |
| Crosswalk between 2020 VTDs and 2010 Census block groups | `vtd_2020_to_bg_2010` | 2021-08-26 | Generated with maup. | Parker Rule |  | `json` | ✅ | `oh_2020_vtds_to_2010_block_groups.json` |
| Crosswalk between 2018 precincts and 2020 Census blocks | `precinct_2018_to_block_2020` | 2021-08-26 | Generated with maup. | Parker Rule |  | `json` | ✅ | `oh_2018_precincts_to_2020_blocks.json` |
| Crosswalk between 2020 precincts and 2010 Census block groups | `precinct_2018_to_bg_2010` | 2021-08-26 | Generated with maup. | Parker Rule |  | `json` | ✅ | `oh_2018_precincts_to_2010_block_groups.json` |
| Crosswalk between 2020 block groups and 2020 Census blocks | `block_group_2020_to_block_2020` | 2021-08-26 | Generated with maup. | Parker Rule |  | `json` | ✅ | `oh_2020_block_groups_to_2020_blocks.json` |
| Crosswalk between 2020 precincts and 2010 Census block groups | `block_group_2020_to_bg_2010` | 2021-08-26 | Generated with maup. | Parker Rule |  | `json` | ✅ | `oh_2020_block_groups_to_2010_block_groups.json` |
