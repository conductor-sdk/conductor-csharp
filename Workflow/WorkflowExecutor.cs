using Conductor.Client.Workflow.Def;
using System.Collections.Generic;

namespace Conductor.Client.Workflow
{
    public class WorkflowExecutor
    {
        private Api.TaskResourceApi _taskClient;
        private Api.WorkflowResourceApi _workflowClient;
        private Api.MetadataResourceApi _metadataClient;

        public WorkflowExecutor
        (
            Api.TaskResourceApi taskClient,
            Api.WorkflowResourceApi workflowClient,
            Api.MetadataResourceApi metadataClient
        )
        {
            _taskClient = taskClient;
            _workflowClient = workflowClient;
            _metadataClient = metadataClient;
        }

        public void RegisterWorkflow(ConductorWorkflow conductorWorkflow, bool overwrite)
        {
            Models.WorkflowDef workflowDef = conductorWorkflow.ToWorkflowDef();
            if (overwrite)
            {
                _metadataClient.UpdateWorkflowDefinitions(
                    new List<Models.WorkflowDef>(1) { workflowDef }
                );
            }
            else
            {
                _metadataClient.Create(workflowDef);
            }
        }
    }
}
