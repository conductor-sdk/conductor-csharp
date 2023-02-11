using Conductor.Api;
using Conductor.Client.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Examples
{
    public class WorkflowApiTests : ApiTest<WorkflowResourceApi>
    {
        private static int WORKFLOW_VERSION = 1;

        [Fact]
        public override void TestMethods()
        {
            String workflowId = _client.StartWorkflow("new_load_test", new Dictionary<string, object>(), WORKFLOW_VERSION);
            _client.Terminate(workflowId, "Operation not supported");
            workflowId = _client.StartWorkflow("new_load_test", new Dictionary<string, object>(), WORKFLOW_VERSION);
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
    }
}
