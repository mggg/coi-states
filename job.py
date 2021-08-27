"""Runs a batch job from a YAML specification (wraps Papermill)."""
import os
import json
import yaml
import click
import papermill as pm
from os.path import join, abspath


@click.command()
@click.argument('module')
@click.argument('job')
@click.option('--root-dir',
              default='.',
              help='Directory containing all modules.')
@click.option('--stage', help='Stage to run in the job.')
def main(module, job, root_dir, stage):
    with open(join(root_dir, module, 'jobs', job + '.yml')) as f:
        specs = yaml.safe_load(f)
    if stage is None:
        stages = specs.get('stages', [])
    else:
        stages = [spec for spec in specs['stages'] if spec['name'] == stage]

    for job_spec in stages:
        print('Stage:', job_spec.get('name', '<untitled>'))
        job_params = {
            'data_dir': abspath(join(root_dir, module, 'data')),
            'output_dir': abspath(join(root_dir, module, 'outputs')),
            **job_spec.get('values', {}).copy()
        }

        # Resolve artifacts.
        artifact_paths = {}
        for artifact_spec in job_spec.get('artifacts', []):
            # If no module is specified for an artifact, use the job's module.
            spec_module = artifact_spec.get('module', module)
            spec_id = artifact_spec['id']
            qualified_id = (spec_module, spec_id)

            if qualified_id not in artifact_paths:
                with open(join(root_dir, spec_module, 'data.yml')) as f:
                    artifacts = yaml.safe_load(f)['artifacts']
                    for artifact in artifacts:
                        artifact_path = join(root_dir, spec_module, 'data',
                                             artifact['path'])
                        artifact_paths[(
                            spec_module,
                            artifact['id'])] = abspath(artifact_path)
            job_params[artifact_spec['param']] = artifact_paths[qualified_id]

        # Invoke notebook with Papermill.
        os.makedirs(job_params['output_dir'], exist_ok=True)
        print(json.dumps(job_params, indent=4))
        input_notebook_path = join(
            root_dir, job_spec['notebooks']['in'].get('module', module),
            'notebooks', job_spec['notebooks']['in']['path'])
        output_notebook_path = join(
            root_dir, job_spec['notebooks']['out'].get('module', module),
            'outputs', job_spec['notebooks']['out']['path'])
        pm.execute_notebook(input_notebook_path,
                            output_notebook_path,
                            parameters=job_params)


if __name__ == '__main__':
    main()