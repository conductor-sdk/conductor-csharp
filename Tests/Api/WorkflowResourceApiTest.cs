using conductor.csharp.Client.Extensions;
using Conductor.Api;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tests.Worker;
using Xunit;

namespace conductor_csharp.test.Api
{
    public class WorkflowResourceApiTest
    {
        private const string WORKFLOW_NAME = "TestToCreateVariables";
        private const string TASK_NAME = "TestToCreateVariables_Task";
        private const string WORKFLOW_VARIABLE_1 = "TestVariable1";
        private const string WORKFLOW_VARIABLE_2 = "TestVariable2";
        private const string WORKFLOW_DESC = "Test Workflow With Variables";
        private const int WORKFLOW_VERSION = 1;

        private readonly WorkflowResourceApi _workflowClient;
        private readonly ILogger _logger;

        public WorkflowResourceApiTest()
        {
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _logger = ApplicationLogging.CreateLogger<WorkerTests>();
        }

        [Fact]
        public async void UpdateWorkflowVariables()
        {
            // Prepare workflow
            var _workflow = GetConductorWorkflow();
            ApiExtensions.GetWorkflowExecutor().RegisterWorkflow(_workflow, true);
            var workflowId = ApiExtensions.GetWorkflowExecutor().StartWorkflow(_workflow);
            await ExecuteWorkflowTasks(workflowCompletionTimeout: TimeSpan.FromSeconds(20));
            await ValidateWorkflowCompletion(workflowId);

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
        }

        private async System.Threading.Tasks.Task ExecuteWorkflowTasks(TimeSpan workflowCompletionTimeout)
        {
            var host = WorkflowTaskHost.CreateWorkerHost(LogLevel.Information, new ClassWorker());
            await host.StartAsync();
            Thread.Sleep(workflowCompletionTimeout);
            await host.StopAsync();
        }

        private ConductorWorkflow GetConductorWorkflow()
        {
            return new ConductorWorkflow()
                .WithName(WORKFLOW_NAME)
                .WithVersion(WORKFLOW_VERSION)
                .WithDescription(WORKFLOW_DESC)
                .WithTask(new SimpleTask(TASK_NAME, TASK_NAME))
                .WithVariable(WORKFLOW_VARIABLE_1, $"{WORKFLOW_VARIABLE_1}_Value")
                .WithVariable(WORKFLOW_VARIABLE_2, $"{WORKFLOW_VARIABLE_2}_Value");
        }

        private async System.Threading.Tasks.Task ValidateWorkflowCompletion(params string[] workflowIdList)
        {
            var workflowStatusList = await WorkflowExtensions.GetWorkflowStatusList(
                _workflowClient,
                maxAllowedInParallel: 10,
                workflowIdList
            );
            var incompleteWorkflowCounter = 0;
            workflowStatusList.ToList().ForEach(wf =>
            {
                if (wf.Status.Value != WorkflowStatus.StatusEnum.COMPLETED)
                {
                    incompleteWorkflowCounter += 1;
                    _logger.LogInformation($"Workflow not completed, workflowId: {wf.WorkflowId}");
                }
            });
            Assert.Equal(0, incompleteWorkflowCounter);
        }
    }
}
