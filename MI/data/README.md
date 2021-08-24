# Michigan Data

Only local artifacts are included in the repository.

| Name | ID | Date | Description | Author(s) | References | Type | Local? | Path |
|------|----|------|-------------|-----------|------------|------|--------|------|
| Census block relationship files [(source)](https://www2.census.gov/geo/docs/maps-data/data/rel2020/t10t20/TAB2010_TAB2020_ST26.zip) | `block_relationship` | 2021-08-12 | Mappings between 2010 Census blocks and 2020 Census blocks. | United States Census Bureau | [U.S. Census relationship files](https://www.census.gov/geographies/reference-files/time-series/geo/relationship-files.html) | `table` | ❌ | `tab2010_tab2020_st26_mi.txt` |
| 2020 Census block shapefile [(source)](https://www2.census.gov/geo/tiger/TIGER2020/TABBLOCK20/tl_2020_26_tabblock20.zip) | `block_shapefile_2020` | 2021-08-12 |  | United States Census Bureau | [U.S. Census TIGER/Line shapefiles](https://www.census.gov/geographies/mapping-files/time-series/geo/tiger-line-file.html) | `shapefile_zip` | ❌ | `tl_2020_26_tabblock20` |
| Portal submissions index | `submissions_index_20210816` | 2021-08-16 | Portal submissions | Parker Rule | [MICRC Public Comment Portal](https://www.michigan-mapping.org/) | `json` | ✅ | `mi_submissions_index_20210816.json` |
| Annotations database dump | `annotations_20210815` | 2021-08-15 | MongoDB annotations database dump. | MGGG annotators, Maxwell Fan, Parker Rule |  | `json` | ✅ | `MI_dump_20210815.jsonl` |
| Cluster database [(source)](https://drive.google.com/uc?id=18GDj1roCxOloQhJiKca4aHQ6eXdcLmjb) | `cluster_db_20210809` | 2021-08-09 | Hausdorff distance-based clusters generated on COI submissions. | Parker Edwards, Ari Stern |  | `pickle` | ❌ | `mi_cluster_db_20210809.pkl` |
| Portal submissions | `submissions_20210810` | 2021-08-10 | Portal submissions database dump (columns are a subset of those in `mi_all_subs_pseudo_cois.csv`). | Parker Rule, Robbie Veglahn |  | `table` | ✅ | `mi_comments_20210809.csv` |
| Crosswalk between 2016 precincts and 2020 Census blocks | `vtd_2016_to_block_2020` | 2021-08-20 | Generated with maup. | Parker Rule |  | `json` | ✅ | `mi_vtds_to_2020_blocks.json` |
| 2016 precinct shapefile [(source)](https://raw.githubusercontent.com/mggg-states/MI-shapefiles/35065e4eca3658fd6c10bfabc11cc12448014674/MI.zip) | `vtd_2016_shapefile` | 2020-12-21 |  | MGGG | [mggg-states repository](https://github.com/mggg-states/MI-shapefiles), [Michigan GIS Open Data](https://gis-michigan.opendata.arcgis.com/) | `shapefile_zip` | ❌ | `MI_precincts_2016` |
| 2010 Census block group shapefile [(source)](https://www2.census.gov/geo/tiger/TIGER2010/BG/2010/tl_2010_26_bg10.zip) | `bg_shapefile_2010` | 2011-01-25 |  | United States Census Bureau | [U.S. Census TIGER/Line shapefiles](https://www.census.gov/geographies/mapping-files/time-series/geo/tiger-line-file.html) | `shapefile_zip` | ❌ | `tl_2010_26_bg10` |
| 2010 block group dual graph | `bg_graph_2010` | 2021-08-22 | Generated with GerryChain from `tl_2010_26_bg10` shapefile. | Parker Rule |  | `json` | ✅ | `tl_2010_26_bg10.json` |
| Portal submissions | `submissions_20210823` | 2021-08-23 | Portal submissions database dump (with media market submissions excluded). | Parker Rule |  | `table` | ✅ | `wi_submissions_20210823.csv` |
| Cluster database | `cluster_db_20210823` | 2021-08-23 | Hausdorff distance-based clusters generated on COI submissions. | Parker Rule |  | `pickle` | ✅ | `wi_cluster_db_20210823.pkl` |
