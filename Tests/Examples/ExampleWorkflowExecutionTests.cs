using Conductor.Api;
using Conductor.Client.Authentication;
using Conductor.Client.Models;
using System;
using System.Collections.Generic;
using Tests.Util;
using Xunit;

namespace Tests.Examples
{
    public class ExampleWorkflowExecutionTests : IntegrationTest
    {
        private static int WORKFLOW_VERSION = 1;
        private MetadataResourceApi _metadataResourceApi;
        private WorkflowResourceApi _workflowResourceApi;

        public ExampleWorkflowExecutionTests()
        {
            OrkesApiClient apiClient = ApiUtil.GetApiClient();
            _metadataResourceApi = apiClient.GetClient<MetadataResourceApi>();
            _workflowResourceApi = apiClient.GetClient<WorkflowResourceApi>();
        }

        [Fact]
        public void TestWorkflowExecutionExample()
        {
            List<TaskDef> taskDefs = GetTaskDefs();
            _metadataResourceApi.RegisterTaskDef(taskDefs);
            List<WorkflowDef> workflowDefs = GetWorkflowDefs();
            _metadataResourceApi.UpdateWorkflowDefinitions(workflowDefs);
            String workflowId = _workflowResourceApi.StartWorkflow("new_load_test", new Dictionary<string, object>(), WORKFLOW_VERSION);
            _workflowResourceApi.Terminate(workflowId, "Operation not supported");
            workflowId = _workflowResourceApi.StartWorkflow("new_load_test", new Dictionary<string, object>(), WORKFLOW_VERSION);
            _workflowResourceApi.PauseWorkflow(workflowId);
            Workflow workflow = _workflowResourceApi.GetExecutionStatus(workflowId);
            Assert.Equal("PAUSED", workflow.Status.ToString());
            _workflowResourceApi.ResumeWorkflow(workflowId);
            workflow = _workflowResourceApi.GetExecutionStatus(workflowId);
            Assert.Equal("RUNNING", workflow.Status.ToString());
        }

        private List<TaskDef> GetTaskDefs()
        {
            return new List<TaskDef>()
            {
                new TaskDef
                (
                    name: "simple_task_0",
                    ownerEmail: "test@orkes.io",
                    timeoutSeconds: 0
                )
            };
        }

        private List<WorkflowDef> GetWorkflowDefs()
        {
            return new List<WorkflowDef>()
            {
                new WorkflowDef
                (
                    name: "new_load_test",
                    tasks: GetWorkflowTasks(),
                    version: 1,
                    timeoutSeconds: 0,
                    ownerEmail: "test@orkes.io",
                    schemaVersion: 2
                )
            };
        }

        private List<WorkflowTask> GetWorkflowTasks()
        {
            return new List<WorkflowTask>()
            {
                new WorkflowTask
                (
                    name:"simple_task_0",
                    taskReferenceName: "simple_task_0",
                    type: "SIMPLE",
                    inputParameters: new Dictionary<string, object>()
                )
            };
        }
    }
}