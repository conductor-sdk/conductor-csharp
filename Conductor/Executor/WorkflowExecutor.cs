using System.Collections.Generic;
using Conductor.Definition;
using Conductor.Api;

namespace Conductor.Executor
{
    public class WorkflowExecutor
    {
        private WorkflowResourceApi _workflowClient;
        private MetadataResourceApi _metadataClient;

        public WorkflowExecutor
        (
            WorkflowResourceApi workflowClient,
            MetadataResourceApi metadataClient
        )
        {
            _workflowClient = workflowClient;
            _metadataClient = metadataClient;
        }

        public void RegisterWorkflow(ConductorWorkflow conductorWorkflow, bool overwrite)
        {
            Models.WorkflowDef workflowDef = conductorWorkflow.ToWorkflowDef();
            if (overwrite)
            {
                _metadataClient.Update
                (
                    new List<Models.WorkflowDef>(1) { workflowDef }
                );
            }
            else
            {
                _metadataClient.Create(workflowDef);
            }
        }

        public string StartWorkflow(ConductorWorkflow conductorWorkflow)
        {
            return _workflowClient.StartWorkflow
            (
                conductorWorkflow.GetStartWorkflowRequest()
            );
        }
    }
}
