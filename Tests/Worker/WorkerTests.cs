using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Conductor.Api;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using conductor.csharp.Client.Extensions;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Microsoft.Extensions.Logging;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace Tests.Worker;

public class WorkerTests
{
    private const string WORKFLOW_NAME = "test-sdk-csharp-worker";
    private const int WORKFLOW_VERSION = 1;
    private const string TASK_NAME = "test-sdk-csharp-task";
    private const string TASK_DOMAIN = "taskDomain";
    private readonly ILogger _logger;

    private readonly WorkflowResourceApi _workflowClient;

    public WorkerTests()
    {
        _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
        _logger = ApplicationLogging.CreateLogger<WorkerTests>();
    }

    [Fact]
    public async Task TestWorkflowAsyncExecution()
    {
        var workflow = GetConductorWorkflow();
        ApiExtensions.GetWorkflowExecutor().RegisterWorkflow(workflow, true);
        var workflowIdList = await StartWorkflows(workflow, 15);
        await ExecuteWorkflowTasks(TimeSpan.FromSeconds(20));
        await ValidateWorkflowCompletion(workflowIdList.ToArray());
    }

    private ConductorWorkflow GetConductorWorkflow()
    {
        return new ConductorWorkflow()
            .WithName(WORKFLOW_NAME)
            .WithVersion(WORKFLOW_VERSION)
            .WithTask(new SimpleTask(TASK_NAME, TASK_NAME));
    }

    private async Task<ConcurrentBag<string>> StartWorkflows(ConductorWorkflow workflow, int quantity)
    {
        var startWorkflowRequest = workflow.GetStartWorkflowRequest();
        startWorkflowRequest.TaskToDomain = new Dictionary<string, string> { { TASK_NAME, TASK_DOMAIN } };
        var startedWorkflows = await WorkflowExtensions.StartWorkflows(
            _workflowClient,
            startWorkflowRequest,
            3,
            quantity
        );
        return startedWorkflows;
    }

    private async Task ExecuteWorkflowTasks(TimeSpan workflowCompletionTimeout)
    {
        var host = WorkflowTaskHost.CreateWorkerHost(LogLevel.Information, new ClassWorker());
        await host.StartAsync();
        Thread.Sleep(workflowCompletionTimeout);
        await host.StopAsync();
    }

    private async Task ValidateWorkflowCompletion(params string[] workflowIdList)
    {
        var workflowStatusList = await WorkflowExtensions.GetWorkflowStatusList(
            _workflowClient,
            10,
            workflowIdList
        );
        var incompleteWorkflowCounter = 0;
        foreach (var workflowStatus in workflowStatusList)
            if (workflowStatus.Status.Value != WorkflowStatus.StatusEnum.COMPLETED)
            {
                incompleteWorkflowCounter += 1;
                _logger.LogInformation($"Workflow not completed, workflowId: {workflowStatus.WorkflowId}");
            }

        Assert.Equal(0, incompleteWorkflowCounter);
    }
}