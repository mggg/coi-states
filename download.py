"""Data downloader for state-level COI submission analysis pipelines."""
import os
import sys
import yaml
import click
import requests
import logging
from io import BytesIO
from zipfile import ZipFile

LOG_LEVEL = logging.INFO
LOG_FMT = '%(asctime)s [%(levelname)s] %(message)s'
DATE_FMT = '%Y-%m-%d'


def generate_gitignore(artifacts):
    """Generates a .gitignore file that excludes nonlocal artifacts."""
    return '\n'.join('/' + artifact['path'] for artifact in artifacts
                     if 'local' not in artifact or not artifact['local'])


def generate_readme(artifacts, name):
    """Generates a Markdown-formatted README from an artifacts manifest."""
    lines = [
        f'# {name} Data', '',
        'Only local artifacts are included in the repository.', '',
        '| Name | ID | Date | Description | Author(s) | References | Type | Local? | Path |',
        '|------|----|------|-------------|-----------|------------|------|--------|------|'
    ]
    # TODO: escaping.
    for artifact in artifacts:
        references = [
            f"[{ref['name']}]({ref['url']})" if 'url' in ref else ref['name']
            for ref in artifact.get('references', [])
        ]
        name = artifact['name']
        if artifact.get('source', '').startswith('http'):
            name += f' [(source)]({artifact["source"]})'

        # yapf: disable
        columns = [
            name,
            f"`{artifact['id']}`",
            artifact['date'].strftime(DATE_FMT) if 'date' in artifact else '',
            artifact.get('description', ''),
            ', '.join(artifact.get('authors', [])),
            ', '.join(references),
            f"`{artifact['type']}`",
            '✅' if artifact.get('local') else '❌',
            f"`{artifact['path']}`"
        ]
        # yapf: enable

        lines.append('| ' + ' | '.join(columns) + ' |')
    return '\n'.join(lines)


def download_artifacts(artifacts, target_dir, force=False):
    """Downloads `artifacts` to `target_dir`."""
    data_dir = os.path.join(target_dir, 'data')
    for artifact in artifacts:
        artifact_id = artifact['id']
        artifact_path = os.path.join(data_dir, artifact['path'])
        if artifact.get('local'):
            # Local artifacts don't need to be downloaded.
            if os.path.exists(artifact_path):
                logging.info("Local artifact '%s' exists.", artifact_id)
            else:
                logging.error("Local artifact '%s' not found at %s.",
                              artifact_id, artifact_path)
        else:
            # Nonlocal artifacts need to be downloaded if they
            # don't exist or if forced redownloading is enabled.
            if not force and os.path.exists(artifact_path):
                logging.info("Artifact '%s' exists.", artifact_id)
            else:
                logging.info("Downloading artifact '%s' from %s", artifact_id,
                             artifact['source'])
                with requests.get(artifact['source']) as req:
                    req.raise_for_status()
                    if 'unzip_target' in artifact:
                        # Extract file from a downloaded ZIP.
                        logging.info("Extracting '%s' for artifact '%s'",
                                     artifact['unzip_target'], artifact_id)
                        with ZipFile(BytesIO(req.content)) as zipfile:
                            with zipfile.open(artifact['unzip_target']) as sf:
                                with open(artifact_path, 'wb') as tf:
                                    tf.write(sf.read())
                    elif artifact['type'] == 'shapefile_zip':
                        # Extract all files in shapefile ZIP.
                        logging.info("Unzipping shapefile for artifact '%s'",
                                     artifact_id)
                        ZipFile(BytesIO(req.content)).extractall(artifact_path)
                    else:
                        # Write raw file contents.
                        with open(artifact_path, 'wb') as f:
                            f.write(req.content)


def data_dirs():
    """Finds child directories (relative to pwd) that contain a `data.yml`."""
    return [
        f.path for f in os.scandir('.')
        if f.is_dir() and os.path.isfile(os.path.join(f.path, 'data.yml'))
    ]


@click.command()
@click.argument('target_dirs', nargs=-1)
@click.option(
    '--all-dirs',
    is_flag=True,
    help=
    'Download data for all child directories that contain a `data.yml` file.')
@click.option('--force',
              '-f',
              is_flag=True,
              help='Redownload artifacts that already exist.')
def main(target_dirs, all_dirs, force):
    if all_dirs and target_dirs:
        logging.error('Cannot specify both target directories and --all-dirs.')
        sys.exit(1)
    if all_dirs:
        target_dirs = data_dirs()
    if not target_dirs:
        logging.warning('No target directories specified.')

    for target in target_dirs:
        with open(os.path.join(target, 'data.yml')) as f:
            # TODO: schema validation.
            manifest = yaml.safe_load(f)
            artifacts = manifest['artifacts']
            manifest_name = manifest['name']
        os.makedirs(os.path.join(target, 'data'), exist_ok=True)

        logging.info("Downloading artifacts for '%s'...", target)
        download_artifacts(artifacts, target, force)

        logging.info("Generating .gitignore for '%s'...", target)
        with open(os.path.join(target, 'data', '.gitignore'), 'w') as f:
            print(generate_gitignore(artifacts), file=f)

        logging.info("Generating README.md for '%s'...", target)
        with open(os.path.join(target, 'data', 'README.md'), 'w') as f:
            print(generate_readme(artifacts, manifest_name), file=f)


if __name__ == '__main__':
    logging.basicConfig(format=LOG_FMT, level=LOG_LEVEL)
    main()
