using Conductor.Api;
using Conductor.Client.Extensions;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Executor;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        private const int WORKFLOW_EXECUTION_TIMEOUT_SECONDS = 5;

        private const int WORKFLOW_QTY = 15;

        private WorkflowExecutor _workflowExecutor = null;

        private WorkflowResourceApi _workflowClient;

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
            GetWorkerHost().RunAsync();
            List<String> workflowIds = StartWorkflows(workflow);
            Thread.Sleep(WORKFLOW_EXECUTION_TIMEOUT_SECONDS * 1000);
            foreach (string workflowId in workflowIds)
            {
                ValidateWorkflowCompletion(workflowId);
            }
        }

        private List<String> StartWorkflows(ConductorWorkflow workflow)
        {
            List<String> workflowIds = new List<string>();
            for (int i = 0; i < WORKFLOW_QTY; i += 1)
            {
                string workflowId = _workflowExecutor.StartWorkflow(workflow);
                workflowIds.Add(workflowId);
            }
            return workflowIds;
        }

        private void ValidateWorkflowCompletion(string workflowId)
        {
            Conductor.Client.Models.WorkflowStatus workflowStatus = _workflowClient.GetWorkflowStatusSummary(workflowId);
            Assert.Equal(
                Conductor.Client.Models.WorkflowStatus.StatusEnum.COMPLETED,
                workflowStatus.Status
            );
        }

        private ConductorWorkflow GetConductorWorkflow()
        {
            return new ConductorWorkflow()
                .WithName(WORKFLOW_NAME)
                .WithVersion(WORKFLOW_VERSION)
                .WithTask(
                    new SimpleTask(TASK_NAME, TASK_NAME)
                );
        }

        private IHost GetWorkerHost()
        {
            return new HostBuilder()
                .ConfigureServices(
                    (ctx, services) =>
                        {
                            services.AddConductorWorker(ApiUtil.GetConfiguration());
                            services.AddConductorWorkflowTask<SimpleWorker>();
                            services.WithHostedService<WorkerService>();
                        }
                ).ConfigureLogging(
                    logging =>
                        {
                            logging.SetMinimumLevel(LogLevel.Debug);
                            logging.AddConsole();
                        }
                ).Build();
        }
    }
}