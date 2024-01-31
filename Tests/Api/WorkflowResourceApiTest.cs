﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using conductor.csharp.Client.Extensions;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Microsoft.Extensions.Logging;
using Tests.Worker;
using Xunit;
using Xunit.Abstractions;
using Task = Conductor.Client.Models.Task;

namespace conductor_csharp.test.Api;

public class WorkflowResourceApiTest
{
    private const string WORKFLOW_NAME = "TestToCreateVariables";
    private const string TASK_NAME = "TestToCreateVariables_Task";
    private const string WORKFLOW_VARIABLE_1 = "TestVariable1";
    private const string WORKFLOW_VARIABLE_2 = "TestVariable2";
    private const string WORKFLOW_DESC = "Test Workflow With Variables";
    private const int WORKFLOW_VERSION = 1;
    private readonly ILogger _logger;
    private readonly ITaskResourceApi _taskClient;
    private readonly ITestOutputHelper _testOutputHelper;

    private readonly WorkflowResourceApi _workflowClient;

    public WorkflowResourceApiTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
        _taskClient = ApiExtensions.GetClient<TaskResourceApi>();
        _logger = ApplicationLogging.CreateLogger<WorkerTests>();
    }

    [Fact]
    public void TestWorkflowOperations()
    {
        // Start Workflow
        var correlationId = Guid.NewGuid().ToString();
        var startWorkflowRequest = new StartWorkflowRequest
        {
            Name = "csharp_sync_task_variable_updates",
            Version = 1,
            Input = new Dictionary<string, object>(),
            CorrelationId = correlationId
        };
        var workflowId = _workflowClient.StartWorkflow(startWorkflowRequest);
        _testOutputHelper.WriteLine($"Started workflow with id {workflowId}");

        // Update a variable inside the workflow 
        _workflowClient.UpdateWorkflowVariables(workflowId, new Dictionary<string, object> { { "case", "case1" } });

        // Get workflow execution status
        var workflow = _workflowClient.GetWorkflow(workflowId, true);
        var lastTask = workflow.Tasks.Last();
        _testOutputHelper.WriteLine(
            $"Workflow status is {workflow.Status} and currently running task is {lastTask.ReferenceTaskName}");

        workflow = _taskClient.UpdateTaskSync(new Dictionary<string, object> { { "a", "b" } }, workflowId,
            lastTask.ReferenceTaskName, TaskResult.StatusEnum.COMPLETED, "test_worker");

        // Get updated workflow status
        lastTask = workflow.Tasks.Last();
        Assert.Equal(lastTask.Status, Task.StatusEnum.INPROGRESS);
        _testOutputHelper.WriteLine(
            $"Workflow status is {workflow.Status} and currently running task is {lastTask.ReferenceTaskName}");

        // Terminate the workflow
        _workflowClient.Terminate(workflowId, "testing termination");
        workflow = _workflowClient.GetWorkflow(workflowId, true);
        Assert.Equal(Workflow.StatusEnum.TERMINATED, workflow.Status);
        lastTask = workflow.Tasks.Last();
        _testOutputHelper.WriteLine(
            $"Workflow status is {workflow.Status} and status of last task {lastTask.Status}");

        // Retry the workflow
        _workflowClient.Retry(workflowId);
        workflow = _workflowClient.GetWorkflow(workflowId, true);
        Assert.Equal(Workflow.StatusEnum.RUNNING, workflow.Status);
        lastTask = workflow.Tasks.Last();
        _testOutputHelper.WriteLine(
            $"Workflow status is {workflow.Status} and status of last task {lastTask.ReferenceTaskName} is {lastTask.Status}");

        // Mark the WAIT task as completed by calling Task completion API
        var taskResult = new TaskResult
        {
            WorkflowInstanceId = workflowId,
            TaskId = lastTask.TaskId,
            Status = TaskResult.StatusEnum.COMPLETED,
            OutputData = new Dictionary<string, object> { { "greetings", "hello from Orkes" } }
        };
        workflow = _taskClient.UpdateTaskSync(
            new Dictionary<string, object> { { "greetings", "hello from Orkes" } },
            workflowId, lastTask.ReferenceTaskName, TaskResult.StatusEnum.COMPLETED, "");

        lastTask = workflow.Tasks.Last();
        Assert.Equal(Task.StatusEnum.SCHEDULED, lastTask.Status);
        _testOutputHelper.WriteLine(
            $"Workflow status is {workflow.Status} and status of last task {lastTask.ReferenceTaskName} is {lastTask.Status}");

        // Terminate the workflow again
        _workflowClient.Terminate(workflowId, "terminating for testing");
        workflow = _workflowClient.GetWorkflow(workflowId, true);
        Assert.Equal(Workflow.StatusEnum.TERMINATED, workflow.Status);


        // Rerun workflow from a specific task
        var rerunRequest = new RerunWorkflowRequest
        {
            ReRunFromTaskId = workflow.Tasks[3].TaskId
        };
        _workflowClient.Rerun(rerunRequest, workflowId);
        workflow = _workflowClient.GetWorkflow(workflowId, true);
        Assert.Equal(Workflow.StatusEnum.RUNNING, workflow.Status);


        // Restart the workflow
        _workflowClient.Terminate(workflowId, "terminating so we can do a restart");
        workflow = _workflowClient.GetWorkflow(workflowId, true);
        Assert.Equal(Workflow.StatusEnum.TERMINATED, workflow.Status);

        _workflowClient.Restart(workflowId);
        workflow = _workflowClient.GetWorkflow(workflowId, true);
        Assert.Equal(Workflow.StatusEnum.RUNNING, workflow.Status);

        // Pause the workflow
        _workflowClient.PauseWorkflow(workflowId);
        workflow = _workflowClient.GetWorkflow(workflowId, true);
        Assert.Equal(Workflow.StatusEnum.PAUSED, workflow.Status);
        _testOutputHelper.WriteLine($"Workflow status is {workflow.Status}");

        workflow = _workflowClient.GetWorkflow(workflowId, true);
        // Wait task should have completed
        var waitTask = workflow.Tasks[0];
        Assert.Equal(Task.StatusEnum.INPROGRESS, waitTask.Status);
        _testOutputHelper.WriteLine($"Workflow status is {workflow.Status} and wait task is {waitTask.Status}");


        // Because workflow is paused, no further task should have been scheduled, making WAIT the last task
        // Expecting only 1 task
        _testOutputHelper.WriteLine($"Number of tasks in workflow is {workflow.Tasks.Count}");
        Assert.Single(workflow.Tasks);

        // Resume the workflow
        _workflowClient.ResumeWorkflow(workflowId);
        lastTask = workflow.Tasks.Last();
        workflow = _taskClient.UpdateTaskSync(new Dictionary<string, object> { { "a", "b" } }, workflowId,
            lastTask.ReferenceTaskName, TaskResult.StatusEnum.COMPLETED, "test_worker");

        workflow = _workflowClient.GetWorkflow(workflowId, true);

        // There should be 3 tasks
        _testOutputHelper.WriteLine(
            $"Number of tasks in workflow is {workflow.Tasks.Count} and last task is {workflow.Tasks.Last().ReferenceTaskName}");
        Assert.Equal(3, workflow.Tasks.Count);

        // Search for workflows
        var searchResults = _workflowClient.Search(start: 0, size: 100, freeText: "*",
            query: $"correlationId = '{correlationId}'");
        _testOutputHelper.WriteLine(
            $"Found {searchResults.Results.Count} execution with correlation_id '{correlationId}'");
        Assert.Single(searchResults.Results);

        correlationId = Guid.NewGuid().ToString();
        searchResults = _workflowClient.Search(start: 0, size: 100, freeText: "*",
            query: $"status IN (RUNNING) AND correlationId = \"{correlationId}\"");
        // Shouldn't find anything!
        _testOutputHelper.WriteLine(
            $"Found {searchResults.Results.Count} workflows with correlation id {correlationId}");
    }

    [Fact]
    public async void UpdateWorkflowVariables()
    {
        // Prepare workflow
        var _workflow = GetConductorWorkflow();
        ApiExtensions.GetWorkflowExecutor().RegisterWorkflow(_workflow, true);
        var workflowId = ApiExtensions.GetWorkflowExecutor().StartWorkflow(_workflow);

        // Create variables collection with values to be updated
        var updateDict = new Dictionary<string, object>
        {
            { WORKFLOW_VARIABLE_1, "Value1" },
            { WORKFLOW_VARIABLE_2, "Value2" }
        };

        // Update the work flow variables 
        _workflowClient.UpdateWorkflowVariables(workflowId, updateDict);
        // Fetch latest workflow data to validate the change in variables
        var _updatedWorkFlow = _workflowClient.GetWorkflowStatusSummary(workflowId, includeVariables: true);
        // Verify workflow variables data is equal with input passed 
        Assert.Equal(_updatedWorkFlow.Variables, updateDict);
    }

    [Fact]
    public void TestUpdateWorkflowState()
    {
        var startWorkflowRequest = new StartWorkflowRequest
        {
            Name = "csharp_sync_task_variable_updates",
            Version = 1,
            Input = new Dictionary<string, object>()
        };
        var workflowRun = _workflowClient.ExecuteWorkflow(startWorkflowRequest,
            Guid.NewGuid().ToString(),
            startWorkflowRequest.Name, startWorkflowRequest.Version,
            "wait_task_ref");

        var workflowId = workflowRun.WorkflowId;
        _testOutputHelper.WriteLine(workflowId);

        var taskResult = new TaskResult
        {
            OutputData = new Dictionary<string, object> { { "a", "b" } }
        };

        var request = new WorkflowStateUpdate
        {
            TaskReferenceName = "wait_task_ref",
            TaskResult = taskResult,
            Variables = new Dictionary<string, object> { { "case", "case1" } }
        };

        workflowRun = _workflowClient.UpdateWorkflow(workflowId, request,
            new List<string> { "wait_task_ref_1", "wait_task_ref_2" }, 10);

        _testOutputHelper.WriteLine(workflowRun.ToString());
        _testOutputHelper.WriteLine(workflowRun.Status.ToString());
        _testOutputHelper.WriteLine(workflowRun.Tasks
            .Select(task => $"{task.ReferenceTaskName}:{task.Status}")
            .ToList().ToString());

        request = new WorkflowStateUpdate
        {
            TaskReferenceName = "wait_task_ref_2",
            TaskResult = taskResult
        };

        workflowRun = _workflowClient.UpdateWorkflow(workflowId, request, new List<string>(), 2);
        Assert.Equal(WorkflowStatus.StatusEnum.RUNNING.ToString(), workflowRun.Status.ToString());

        request = new WorkflowStateUpdate
        {
            TaskReferenceName = "simple_task_ref",
            TaskResult = taskResult
        };
        workflowRun = _workflowClient.UpdateWorkflow(workflowId, request, new List<string>(), 2);

        var allTaskStatus = workflowRun.Tasks
            .Select(t => t.Status)
            .ToHashSet();

        Assert.Single(allTaskStatus);
        Assert.Equal(Task.StatusEnum.COMPLETED.ToString(), allTaskStatus.First().ToString());

        _testOutputHelper.WriteLine(workflowRun.Status.ToString());
        _testOutputHelper.WriteLine(workflowRun.Tasks
            .Select(task => $"{task.ReferenceTaskName}:{task.Status}")
            .ToList().ToString());
    }


    [Fact]
    public void TestStartWorkflowConflict()
    {
        var startWorkflowRequest = new StartWorkflowRequest
        {
            Name = "csharp_sync_task_variable_updates",
            Version = 1
        };

        var idempotencyKey = Guid.NewGuid().ToString();
        startWorkflowRequest.IdempotencyKey = idempotencyKey;
        startWorkflowRequest.IdempotencyStrategy = IdempotencyStrategy.FAIL;

        var workflowId = _workflowClient.StartWorkflow(startWorkflowRequest);
        _testOutputHelper.WriteLine(workflowId);

        startWorkflowRequest.IdempotencyStrategy = IdempotencyStrategy.RETURN_EXISTING;
        var workflowId2 = _workflowClient.StartWorkflow(startWorkflowRequest);
        Assert.Equal(workflowId, workflowId2);

        startWorkflowRequest.IdempotencyStrategy = IdempotencyStrategy.FAIL;
        var conflict = false;

        try
        {
            _workflowClient.StartWorkflow(startWorkflowRequest);
        }
        catch (ApiException ce)
        {
            if (ce.ErrorCode == 409) conflict = true;
        }

        Assert.True(conflict);
    }

    private async System.Threading.Tasks.Task ExecuteWorkflowTasks(TimeSpan workflowCompletionTimeout)
    {
        var host = WorkflowTaskHost.CreateWorkerHost(LogLevel.Information,
            new ClassWorker("TestToCreateVariables_Task"));
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
            10,
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