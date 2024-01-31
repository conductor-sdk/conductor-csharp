using conductor.csharp.Client.Extensions;
using Conductor.Api;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tests.Worker;
using Xunit;

namespace conductor_csharp.test.Api
{
    public class WorkflowResourceApiTest
    {
        private const string WORKFLOW_NAME = "TestToCreateVariables";
        private const string TASK_NAME = "TesttoCreateVaribles_task";
        private const string WORKFLOW_VARIABLE_1 = "TestVariable1";
        private const string WORKFLOW_VARIABLE_2 = "TestVariable2";
        private const string WORKFLOW_DESC = "Test Workflow With Variables";
        private const int WORKFLOW_VERSION = 1;
        private const string OWNER_EMAIL = "<REPLACE_WITH_OWNER_EMAIL>";

        //private readonly OrkesApiClient _orkesApiClient;
        private readonly WorkflowResourceApi _workflowClient;
        private readonly MetadataResourceApi _metadataResourceApi;
        private readonly ILogger _logger;

        public WorkflowResourceApiTest()
        {
            // Dev local test
            //_orkesApiClient = new OrkesApiClient(new Configuration(), new OrkesAuthenticationSettings("<Key_Id>", "<Key_Secret>"));
            //_workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
            //_metadataResourceApi = _orkesApiClient.GetClient<MetadataResourceApi>();

            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _metadataResourceApi = ApiExtensions.GetClient<MetadataResourceApi>();
            _logger = ApplicationLogging.CreateLogger<WorkerTests>();
        }

        [Fact]
        public async void ResumeWorkflow()
        {
            var workflowId = RegisterAndStartWorkflow();

            _workflowClient.PauseWorkflow(workflowId);
            _workflowClient.ResumeWorkflow(workflowId);
            var res = _workflowClient.GetExecutionStatus(workflowId);
            Assert.NotNull(res);
            Assert.Equal(Workflow.StatusEnum.RUNNING, res.Status);
            DeleteWorkflowExecution(workflowId);
        }

        [Fact]
        public async void DeleteWorkflow()
        {
            var workflowId = RegisterAndStartWorkflow();

            _workflowClient.Delete(workflowId);
            var res = _workflowClient.GetRunningWorkflowWithHttpInfo(WORKFLOW_NAME);
            Assert.NotNull(res);
            Assert.DoesNotContain(workflowId, res.Data);
        }

        [Fact]
        public async void TerminateWorkflow()
        {
            var workflowId = RegisterAndStartWorkflow();

            _workflowClient.Terminate(workflowId);
            var res = _workflowClient.GetExecutionStatus(workflowId);
            Assert.NotNull(res);
            Assert.Equal(Workflow.StatusEnum.TERMINATED, res.Status);
            DeleteWorkflowExecution(workflowId);
        }

        [Fact]
        public async void RetryLastFailedWorkflow()
        {
            var workflowId = RegisterAndStartWorkflow();

            _workflowClient.Terminate(workflowId);
            _workflowClient.Retry(workflowId);
            var res = _workflowClient.GetExecutionStatus(workflowId);
            Assert.NotNull(res);
            Assert.Equal(Workflow.StatusEnum.RUNNING, res.Status);
            DeleteWorkflowExecution(workflowId);
        }


        [Fact]
        public async void PauseWorkflowExecution()
        {
            var workflowId = RegisterAndStartWorkflow();

            _workflowClient.PauseWorkflow(workflowId);
            var res = _workflowClient.GetExecutionStatus(workflowId);
            Assert.NotNull(res);
            Assert.Equal(Workflow.StatusEnum.PAUSED, res.Status);
            DeleteWorkflowExecution(workflowId);
        }

        [Fact]
        public async void UpdateWorkflowVariables()
        {
            // Prepare workflow
            var workflowId = RegisterAndStartWorkflow();

            // Create variables collection with values to be updated
            var updateDict = new Dictionary<string, object> {
                      {WORKFLOW_VARIABLE_1,"Value1" },
                      {WORKFLOW_VARIABLE_2,"Value2" },
                  };
            var updateVariableData = new Workflow() { WorkflowId = workflowId, Variables = updateDict };
            // Update the work flow variables 
            _workflowClient.UpdateWorkflowVariables(updateVariableData);
            // Fetch latest workflow data to validate the change in variables
            var _updatedWorkFlow = _workflowClient.GetWorkflowStatusSummary(workflowId, includeVariables: true);
            // Verify workflow variables data is equal with input passed 
            Assert.Equal(_updatedWorkFlow.Variables, updateDict);

            DeleteWorkflowExecution(workflowId);
        }

        private string RegisterAndStartWorkflow()
        {
            var _workflow = GetConductorWorkflow();
            _metadataResourceApi.UpdateWorkflowDefinitions(new List<WorkflowDef>(1) { _workflow }, true);
            var workflowId = _workflowClient.StartWorkflow(new StartWorkflowRequest(name: WORKFLOW_NAME));

            return workflowId;
        }

        private ConductorWorkflow GetConductorWorkflow()
        {
            return new ConductorWorkflow()
                .WithName(WORKFLOW_NAME)
                .WithVersion(WORKFLOW_VERSION)
                .WithDescription(WORKFLOW_DESC)
                .WithOwner(OWNER_EMAIL)
                .WithTask(new SimpleTask(TASK_NAME, TASK_NAME))
                .WithVariable(WORKFLOW_VARIABLE_1, $"{WORKFLOW_VARIABLE_1}_Value")
                .WithVariable(WORKFLOW_VARIABLE_2, $"{WORKFLOW_VARIABLE_2}_Value");
        }


        private void DeleteWorkflowExecution(string workflowId)
        {
            _workflowClient.Delete(workflowId);

            var res = _workflowClient.GetRunningWorkflowWithHttpInfo(WORKFLOW_NAME);
            Assert.NotNull(res);
            Assert.DoesNotContain(workflowId, res.Data);
        }

        //[Fact]
        //public void DeleteAllWorkflowExecution()
        //{

        //    var res = _workflowClient.GetRunningWorkflowWithHttpInfo(WORKFLOW_NAME);

        //    res.Data.ForEach(x => _workflowClient.Delete(x));

        //    res = _workflowClient.GetRunningWorkflowWithHttpInfo(WORKFLOW_NAME);

        //    Assert.Equal(0, res.Data.Count);
        //}
    }
}
