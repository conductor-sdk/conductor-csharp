using Conductor.Api;
using Conductor.Client.Extensions;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Executor;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Conductor.Client.Worker;
using Conductor.Client.Interfaces;
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
        private const int WORKFLOW_EXECUTION_TIMEOUT_SECONDS = 5;

        private WorkflowExecutor _workflowExecutor = null;

        public WorkerTests()
        {
            _workflowExecutor = ApiUtil.GetWorkflowExecutor();
        }

        [Fact]
        public void TestWorkflowAsyncExecution()
        {
            ConductorWorkflow workflow = GetConductorWorkflow();
            _workflowExecutor.RegisterWorkflow(workflow, true);
            GetWorkerHost().Run();
            string workflowId = _workflowExecutor.StartWorkflow(workflow);
            Console.WriteLine("workflowId: " + workflowId);
            Thread.Sleep(WORKFLOW_EXECUTION_TIMEOUT_SECONDS * 1000);
            WorkflowResourceApi workflowClient = ApiUtil.GetClient<WorkflowResourceApi>();
            Conductor.Client.Models.WorkflowStatus workflowStatus = workflowClient.GetWorkflowStatusSummary(workflowId);
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
                            services.WithOrkesApiClient(ApiUtil.GetApiClient());
                            services.WithConductorWorker<SimpleWorker>();
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
