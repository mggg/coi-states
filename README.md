# COI Submission Analysis

This repository contains data, notebooks, and pipelines for analyzing communities of interest submitted to MGGG via [Districtr](https://districtr.org/). 

## Scope
We currently maintain pipelines for four states:
* Michigan [(MICRC Public Comment Portal)](https://www.michigan-mapping.org/)
* Missouri [(MO Redistricting Public Comment Portal)](https://portal.missouri-mapping.org/)
* Ohio [(OH Redistricting Public Comment Portal)](https://portal.ohio-mapping.org/)
* Wisconsin [(PMC Public Comment Portal)](https://portal.wisconsin-mapping.org/)

## Geting started
This repository is organized into modules: one for each state (`MI`, `MO`, `OH`, '`WI`), plus a module for common/nationwide data (`common`). We use `download.py` to manage data dependencies and `job.py` into invoke jobs. (The job manager is a thin wrapper around [Papermill](https://papermill.readthedocs.io/en/latest/).)

### Setting up dependencies
Create a Conda environment with the necessary dependencies:
```sh
conda create --name coi --file requirements.txt
```

Then, install the latest version of `submission-analysis`:
```sh
pip install git+https://github.com/mggg/submission-analysis
```

### Downloading data
`download.py` supports raw file downloads and Census API queries. (API keys are [available for free](https://api.census.gov/data/key_signup.html).) To download all non-local data (e.g. Census shapefiles) for all states, run:
```sh
python download.py --all-dirs --census-api-key <YOUR API KEY>
```

Data downloads are incremental, so a Census API key is only necessary for the first download and after the addition of a new Census API-based dataset. To update non-Census API data for a specific module (e.g. `OH`), run:
```sh
python download.py <MODULE>
```

### Running jobs
To start a job, run:
```sh
python job.py <MODULE> <JOB NAME>
```

For instance, `python job.py OH 20210902_pipeline` loads and executes the job manifest `OH/jobs/20210902_pipeline.yml`. Individual job stages can be included or excluded with `--include` and `--exclude`. 

## Adding data
TODO

### Direct download

### Census API

### Local data

## Adding jobs
TODO
