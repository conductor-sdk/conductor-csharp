using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Conductor.Definition;
using Conductor.Api;
using Conductor.Definition.TaskType;
using Conductor.Executor;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tests.Util;
using System.Threading;
using System.Collections.Generic;
using Xunit;

using System;

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
            StartWorkers();
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

        private void StartWorkers()
        {
            //     System.Threading.Tasks.Task host = new HostBuilder()
            //         .ConfigureServices(
            //             (ctx, services) =>
            //                 {
            //                     services.AddConductorWorker(ApiUtil.GetApiClient());
            //                     services.AddConductorWorkflowTask<SimpleWorker>();
            //                     services.AddWorkflowsWorkerService<WorkflowsWorkerService>();
            //                 }
            //         ).ConfigureLogging(
            //             logging =>
            //                 {
            //                     logging.SetMinimumLevel(LogLevel.Debug);
            //                     logging.AddConsole();
            //                 }
            //         ).RunConsoleAsync();
        }
    }

    // internal class WorkflowsWorkerService : BackgroundService
    // {
    //     private readonly IWorkflowTaskCoordinator _workflowTaskCoordinator;
    //     private readonly IEnumerable<IWorkflowTask> _workers;

    //     public WorkflowsWorkerService(
    //         IWorkflowTaskCoordinator workflowTaskCoordinator,
    //         List<IWorkflowTask> workers
    //     )
    //     {
    //         _workflowTaskCoordinator = workflowTaskCoordinator;
    //         _workers = workers;
    //     }

    //     protected override System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
    //     {
    //         foreach (var worker in _workers)
    //         {
    //             _workflowTaskCoordinator.RegisterWorker(worker);
    //         }
    //         return _workflowTaskCoordinator.Start();
    //     }
    // }
}
