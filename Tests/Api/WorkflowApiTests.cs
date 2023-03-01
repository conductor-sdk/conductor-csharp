using Conductor.Api;
using Conductor.Client.Models;
using System;
using System.Collections.Generic;
using Tests.Util;
using Xunit;

namespace Tests.Examples
{
    public class WorkflowApiTests : ApiTest<WorkflowResourceApi>
    {
        private static int WORKFLOW_VERSION = 1;

        [Fact]
        public override void TestMethods()
        {
            RegisterWorkflow();
            ValidateWorkflowExecution();
        }

        private void ValidateWorkflowExecution()
        {
            String workflowId = _client.StartWorkflow(RANDOM_WORKFLOW_NAME, new Dictionary<string, object>(), WORKFLOW_VERSION);
            _client.Terminate(workflowId, "some relevant reason");
            workflowId = _client.StartWorkflow(RANDOM_WORKFLOW_NAME, new Dictionary<string, object>(), WORKFLOW_VERSION);
            _client.PauseWorkflow(workflowId);
            Workflow workflow = _client.GetExecutionStatus(workflowId);
            Assert.Equal("PAUSED", workflow.Status.ToString());
            _client.ResumeWorkflow(workflowId);
            workflow = _client.GetExecutionStatus(workflowId);
            Assert.Equal("RUNNING", workflow.Status.ToString());
            _client.Terminate(
                workflowId: workflowId,
                triggerFailureWorkflow: true
            );
            workflow = _client.GetExecutionStatus(workflowId);
            Assert.Equal(Workflow.StatusEnum.TERMINATED, workflow.Status);
        }

        public void RegisterWorkflow()
        {
            var client = ApiUtil.GetClient<MetadataResourceApi>();
            client.RegisterTaskDef(GetTaskDefs());
            client.UpdateWorkflowDefinitions(GetWorkflowDefs());
        }

        private List<TaskDef> GetTaskDefs()
        {
            return new List<TaskDef>()
            {
                new TaskDef
                (
                    name: RANDOM_TASK_NAME,
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
                    name: RANDOM_WORKFLOW_NAME,
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
                    name: RANDOM_TASK_NAME,
                    taskReferenceName: RANDOM_TASK_NAME,
                    type: "SIMPLE",
                    inputParameters: new Dictionary<string, object>()
                )
            };
        }
    }
}
