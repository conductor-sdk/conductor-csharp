using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Models;
using Conductor.Definition;
using System.Collections.Generic;

namespace Conductor.Executor
{
    public class WorkflowExecutor
    {
        private WorkflowResourceApi _workflowClient;
        private MetadataResourceApi _metadataClient;

        public WorkflowExecutor(Configuration configuration)
        {
            _workflowClient = configuration.GetClient<WorkflowResourceApi>();
            _metadataClient = configuration.GetClient<MetadataResourceApi>();
        }

        public WorkflowExecutor(WorkflowResourceApi workflowClient, MetadataResourceApi metadataClient)
        {
            _workflowClient = workflowClient;
            _metadataClient = metadataClient;
        }

        public void RegisterWorkflow(WorkflowDef workflow, bool overwrite)
        {
            if (overwrite)
            {
                _metadataClient.UpdateWorkflowDefinitions(new List<WorkflowDef>(1) { workflow });
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
