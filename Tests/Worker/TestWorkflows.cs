using conductor.csharp.Client.Extensions;
using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Executor;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Xunit;

namespace conductor_csharp.test.Worker
{
    public class TestWorkflows
    {
        private readonly OrkesApiClient _orkesApiClient;
        private readonly WorkflowResourceApi workflowClient;
        private readonly WorkflowExecutor _workflowExecutor;
        private ILogger _logger;

        public TestWorkflows()
        {
            var config = new Configuration();
            _workflowExecutor = new WorkflowExecutor(config);
            workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _logger = ApplicationLogging.CreateLogger<TestWorkflows>();

            //For local testing
            //_orkesApiClient = new OrkesApiClient(config, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
        }

        [Fact]
        public void TestWorkflowExecution()
        {
            var workflow = new ConductorWorkflow()
            .WithName("unit_testing_example")
            .WithDescription("test unit test")
            .WithVersion(1);
            var task1 = new SimpleTask("hello_C_1", "hello_ref_C_1");
            var task2 = new SimpleTask("hello_C_2", "hello_ref_C_2");
            var task3 = new SimpleTask("hello_C_3", "hello_ref_C_3");


            var decision = new SwitchTask("switch_ref", task1.Output("city"));
            decision.WithDecisionCase("NYC", task2);
            decision.WithDefaultCase(task3);

            var http = new HttpTask("http", new HttpTaskSettings { uri = "https://orkes-api-tester.orkesconductor.com/api" });
            workflow.WithTask(http);
            workflow.WithTask(task1);
            workflow.WithTask(decision);

            var taskRefToMockOutput = new Dictionary<string, List<TaskMock>>();

            taskRefToMockOutput[task1.TaskReferenceName] = new List<TaskMock>
{
new TaskMock { ExecutionTime= 1, Status = TaskMock.StatusEnum.FAILED, QueueWaitTime= 10, Output = new Dictionary<string, Object> {{ "key", "failed" }}},
new TaskMock{ ExecutionTime= 1, Status = TaskMock.StatusEnum.COMPLETED, QueueWaitTime=10, Output = new Dictionary<string, Object> {{"city", "NYC"}}}
};

            taskRefToMockOutput[task2.TaskReferenceName] = new List<TaskMock>
{
new TaskMock{ ExecutionTime= 1, Status = TaskMock.StatusEnum.COMPLETED, QueueWaitTime= 10, Output = new Dictionary < string, Object > {{ "key", "task2.output" }}}
};

            taskRefToMockOutput[http.TaskReferenceName] = new List<TaskMock>
{
new TaskMock{ ExecutionTime= 1, Status = TaskMock.StatusEnum.COMPLETED, QueueWaitTime= 10, Output = new Dictionary<string, Object> {{"key", "http.output"}}}
};

            _workflowExecutor.RegisterWorkflow(workflow, true);

            var testRequest = new WorkflowTestRequest(name: workflow.Name, version: workflow.Version, taskRefToMockOutput: taskRefToMockOutput, workflowDef: workflow);
            var run = workflowClient.TestWorkflow(testRequest);

            _logger.LogInformation($"Completed the test run {run}");
            _logger.LogInformation($"Status: {run.Status}");
            Assert.Equal("COMPLETED", run.Status.ToString());

            _logger.LogInformation($"First task (HTTP) status: {run.Tasks[0].TaskType}");
            Assert.Equal("HTTP", run.Tasks[0].TaskType);

            _logger.LogInformation($"{run.Tasks[1].ReferenceTaskName} status: {run.Tasks[1].Status} (expected to be FAILED)");
            Assert.Equal("FAILED", run.Tasks[1].Status.ToString());

            _logger.LogInformation($"{run.Tasks[2].ReferenceTaskName} status: {run.Tasks[2].Status} (expected to be COMPLETED)");
            Assert.Equal("COMPLETED", run.Tasks[2].Status.ToString());

            _logger.LogInformation($"{run.Tasks[4].ReferenceTaskName} status: {run.Tasks[4].Status} (expected to be COMPLETED)");
            Assert.Equal("COMPLETED", run.Tasks[4].Status.ToString());

            //Assert that task2 was executed
            Assert.Equal(task2.TaskReferenceName, run.Tasks[4].ReferenceTaskName);
        }
    }
}