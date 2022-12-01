using System;
using Conductor.Client.Extensions;
using Conductor.Interfaces;
using Conductor.Client.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Task = System.Threading.Tasks.Task;
using Conductor;
using System.Collections.Concurrent;

namespace Examples
{
    class Worker
    {
        [Obsolete]
        void Main(string[] args)
        {
            new HostBuilder()
                 .ConfigureServices((ctx, services) =>
                 {

                     Configuration configuration = new Configuration(new ConcurrentDictionary<string, string>(),
                     "", "", "http://localhost:8080/");
                     services.AddConductorWorker(configuration);
                     services.AddConductorWorkflowTask<MyWorkflowTask>();
                     services.AddHostedService<WorkflowsWorkerService>();
                 })
                 .ConfigureLogging(logging =>
                 {
                     logging.SetMinimumLevel(LogLevel.Debug);
                     logging.AddConsole();
                 }).Build().Run();
            Console.ReadLine();

        }
    }

    internal class WorkflowsWorkerService : BackgroundService
    {
        private readonly IWorkflowTaskCoordinator workflowTaskCoordinator;
        private readonly IEnumerable<IWorkflowTask> workflowTasks;

        public WorkflowsWorkerService(
            IWorkflowTaskCoordinator workflowTaskCoordinator,
            IEnumerable<IWorkflowTask> workflowTasks
        )
        {
            this.workflowTaskCoordinator = workflowTaskCoordinator;
            this.workflowTasks = workflowTasks;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            foreach (var worker in workflowTasks)
            {
                workflowTaskCoordinator.RegisterWorker(worker);
            }
            await workflowTaskCoordinator.Start();
        }
    }

    internal class MyWorkflowTask : IWorkflowTask
    {
        public MyWorkflowTask() { }

        public string TaskType => "simple_task_0";
        public int? Priority => null;

        public Task<TaskResult> Execute(Models.Task task, CancellationToken token)
        {
            Dictionary<string, object> newOutput = new Dictionary<string, object>();
            Random rnd = new Random();
            newOutput.Add("value", rnd.Next(1, 10));
            return System.Threading.Tasks.Task.FromResult(task.Completed(task.OutputData.MergeValues(newOutput)));
        }
    }
}



