# Missouri Data

Only local artifacts are included in the repository.

| Name | ID | Date | Description | Author(s) | References | Type | Local? | Path |
|------|----|------|-------------|-----------|------------|------|--------|------|
| Census block relationship files [(source)](https://www2.census.gov/geo/docs/maps-data/data/rel2020/t10t20/TAB2010_TAB2020_ST29.zip) | `block_relationship` | 2021-08-12 | Mappings between 2010 Census blocks and 2020 Census blocks. | United States Census Bureau | [U.S. Census relationship files](https://www.census.gov/geographies/reference-files/time-series/geo/relationship-files.html) | `table` | ❌ | `tab2010_tab2020_st29_mo.txt` |
| 2020 Census block shapefile [(source)](https://www2.census.gov/geo/tiger/TIGER2020/TABBLOCK20/tl_2020_29_tabblock20.zip) | `block_2020_shapefile` | 2021-08-12 |  | United States Census Bureau | [U.S. Census TIGER/Line shapefiles](https://www.census.gov/geographies/mapping-files/time-series/geo/tiger-line-file.html) | `shapefile_zip` | ❌ | `tl_2020_29_tabblock20` |
| Portal submissions index | `submissions_index_20210819` | 2021-08-19 | Portal submissions | Parker Rule | [Missouri Public Comment Portal](https://portal.missouri-mapping.org/) | `json` | ✅ | `mo_submissions_index_20210819.json` |
| Annotations database dump | `annotations_20210815` | 2021-08-15 | MongoDB annotations database dump. | MGGG annotators, Maxwell Fan, Parker Rule |  | `json` | ✅ | `MO_dump_20210815.jsonl` |
| Cluster database [(source)](https://drive.google.com/uc?id=1xwqeUh0HzvQ1sTbSvIuFZH4edimG7uxO) | `cluster_db_20210809` | 2021-08-09 | Hausdorff distance-based clusters generated on COI submissions. | Parker Edwards, Ari Stern |  | `pickle` | ❌ | `mo_cluster_db_20210809.pkl` |
| Cluster database | `cluster_db_20210823` | 2021-08-23 | Hausdorff distance-based clusters generated on COI submissions. | Parker Rule |  | `pickle` | ✅ | `mo_cluster_db_20210823.pkl` |
| Portal submissions | `submissions_20210810` | 2021-08-10 | Portal submissions database dump. | Robbie Veglahn |  | `table` | ✅ | `MOCumulativeAug10.csv` |
| 2010 Census block group shapefile [(source)](https://www2.census.gov/geo/tiger/TIGER2010/BG/2010/tl_2010_29_bg10.zip) | `bg_shapefile_2010` | 2010-12-21 |  | United States Census Bureau | [U.S. Census TIGER/Line shapefiles](https://www.census.gov/geographies/mapping-files/time-series/geo/tiger-line-file.html) | `shapefile_zip` | ❌ | `tl_2010_29_bg10` |
| 2010 block group dual graph | `bg_2010_graph` | 2021-08-23 | Generated with GerryChain from `tl_2010_29_bg10` shapefile. | Parker Rule |  | `json` | ✅ | `tl_2010_29_bg10.json` |
| 2020 Census block dual graph | `block_2020_graph` | 2021-08-27 | Generated with GerryChain from `tl_2020_29_tabblock20` shapefile. | Parker Rule |  | `json` | ✅ | `tl_2020_29_tabblock20.json` |
| Portal submissions | `submissions_20210823` | 2021-08-23 | Portal submissions database dump. | Parker Rule |  | `table` | ✅ | `mo_submissions_20210823.csv` |
| Cluster database | `cluster_db_20210809_new_format` | 2021-08-27 | Hausdorff distance-based clusters generated on COI submissions (new format). | Parker Edwards, Parker Rule, Ari Stern |  | `pickle` | ✅ | `mo_cluster_db_20210809_new_format.pkl` |
