using Conductor.Api;
using Conductor.Client.Models;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Executor;
using Microsoft.Extensions.Hosting;
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
        public void TestWorkflowAsyncExecution()
        {
            ConductorWorkflow workflow = GetConductorWorkflow();
            _workflowExecutor.RegisterWorkflow(workflow, true);
            var workflowIdList = StartWorkflows(workflow, 15);
            CompleteWorkflows(TimeSpan.FromSeconds(10));
            ValidateWorkflowCompletion(workflowIdList.ToArray());
        }

        private ConductorWorkflow GetConductorWorkflow()
        {
            return new ConductorWorkflow()
                .WithName(WORKFLOW_NAME)
                .WithVersion(WORKFLOW_VERSION)
                .WithTask(new SimpleTask(TASK_NAME, TASK_NAME));
        }

        private ConcurrentBag<string> StartWorkflows(ConductorWorkflow workflow, int quantity)
        {
            var startedWorkflows = WorkflowUtil.StartWorkflows(
                _workflowClient, workflow, Environment.ProcessorCount * 2, quantity);
            startedWorkflows.Wait();
            return startedWorkflows.Result;
        }

        private void CompleteWorkflows(TimeSpan timeSpan)
        {
            var host = WorkerUtil.GetWorkerHost();
            var cts = new CancellationTokenSource();
            host.RunAsync(cts.Token);
            Thread.Sleep(timeSpan);
            cts.Cancel();
            host.WaitForShutdown();
        }

        private void ValidateWorkflowCompletion(string[] workflowIdList)
        {
            var workflowStatusList = WorkflowUtil.GetWorkflowStatusList(
                _workflowClient, Environment.ProcessorCount << 1, workflowIdList);
            workflowStatusList.Wait();
            foreach (var workflowStatus in workflowStatusList.Result)
            {
                Assert.Equal(Workflow.StatusEnum.COMPLETED.ToString(), workflowStatus.Status.ToString());
            }
        }
    }
}