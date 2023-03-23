using Conductor.Api;
using Conductor.Client.Models;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Executor;
using System;
using System.Collections.Concurrent;
using System.Threading;
using Tests.Util;
using Xunit;

namespace Tests.Worker
{
    public class WorkerTests
    {
        private const string WORKFLOW_NAME = "test-sdk-csharp-worker";
        private const int WORKFLOW_VERSION = 1;

        private const string TASK_NAME = "test-sdk-csharp-task";

        private readonly WorkflowExecutor _workflowExecutor;

        private readonly WorkflowResourceApi _workflowClient;

        public WorkerTests()
        {
            _workflowExecutor = ApiUtil.GetWorkflowExecutor();
            _workflowClient = ApiUtil.GetClient<WorkflowResourceApi>();
        }

        [Fact]
        public async System.Threading.Tasks.Task TestWorkflowAsyncExecution()
        {
            ConductorWorkflow workflow = GetConductorWorkflow();
            _workflowExecutor.RegisterWorkflow(workflow, true);
            var workflowIdList = await StartWorkflows(workflow, quantity: 60);
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

        private async System.Threading.Tasks.Task<ConcurrentBag<string>> StartWorkflows(ConductorWorkflow workflow, int quantity)
        {
            var startedWorkflows = await WorkflowUtil.StartWorkflows(
                _workflowClient,
                workflow,
                Math.Max(15, Environment.ProcessorCount << 1),
                quantity);
            return startedWorkflows;
        }

        private async System.Threading.Tasks.Task ExecuteWorkflowTasks(TimeSpan workflowCompletionTimeout)
        {
            var host = WorkerUtil.GetWorkerHost();
            await host.StartAsync();
            Thread.Sleep(workflowCompletionTimeout);
            await host.StopAsync();
        }

        private async System.Threading.Tasks.Task ValidateWorkflowCompletion(params string[] workflowIdList)
        {
            var workflowStatusList = await WorkflowUtil.GetWorkflowStatusList(
                _workflowClient,
                Math.Max(15, Environment.ProcessorCount << 1),
                workflowIdList);
            int incompleteWorkflowCounter = 0;
            foreach (var workflowStatus in workflowStatusList)
            {
                if (workflowStatus.Status.Value != WorkflowStatus.StatusEnum.COMPLETED)
                {
                    incompleteWorkflowCounter += 1;
                    Console.WriteLine($"Workflow not completed, workflowId: {workflowStatus.WorkflowId}");
                }
            }
            Assert.Equal(0, incompleteWorkflowCounter);
        }
    }
}