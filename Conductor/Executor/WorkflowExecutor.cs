using Conductor.Api;
using Conductor.Definition;
using Conductor.Client.Models;
using System.Collections.Generic;

namespace Conductor.Executor
{
    public class WorkflowExecutor
    {
        private WorkflowResourceApi _workflowClient;
        private MetadataResourceApi _metadataClient;

        public WorkflowExecutor(WorkflowResourceApi workflowClient, MetadataResourceApi metadataClient)
        {
            _workflowClient = workflowClient;
            _metadataClient = metadataClient;
        }

        public void RegisterWorkflow(WorkflowDef workflow, bool overwrite)
        {
            if (overwrite)
            {
                _metadataClient.Update(new List<WorkflowDef>(1) { workflow });
            }
            else
            {
                _metadataClient.Create(workflow);
            }
        }

        public string StartWorkflow(ConductorWorkflow conductorWorkflow)
        {
            return StartWorkflow(conductorWorkflow.GetStartWorkflowRequest());
        }

        public string StartWorkflow(StartWorkflowRequest startWorkflowRequest)
        {
            return _workflowClient.StartWorkflow(startWorkflowRequest);
        }
    }
}
