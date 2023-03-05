using Conductor.Api;
using Conductor.Client.Models;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Executor;
using Microsoft.Extensions.Hosting;
using System;

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
            var startedWorkflows = WorkflowUtil.StartWorkflows(
                _workflowClient, workflow, Environment.ProcessorCount * 2, 15);
            startedWorkflows.Wait();
            WorkerUtil.GetWorkerHost().RunAsync();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            var workflowStatusList = WorkflowUtil.GetWorkflowStatusList(
                _workflowClient, Environment.ProcessorCount << 1, startedWorkflows.Result.ToArray());
            workflowStatusList.Wait();
            foreach (var workflowStatus in workflowStatusList.Result)
            {
                Assert.Equal(Workflow.StatusEnum.COMPLETED.ToString(), workflowStatus.Status.ToString());
            }
        }

        private ConductorWorkflow GetConductorWorkflow()
        {
            return new ConductorWorkflow()
                .WithName(WORKFLOW_NAME)
                .WithVersion(WORKFLOW_VERSION)
                .WithTask(new SimpleTask(TASK_NAME, TASK_NAME));
        }
    }
}