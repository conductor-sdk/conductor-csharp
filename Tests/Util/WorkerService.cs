using Conductor.Client.Interfaces;
using Conductor.Client.Worker;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace Tests.Util
{
    public class WorkerService : BackgroundService
    {
        private readonly IWorkflowTaskCoordinator _workflowTaskCoordinator;
        private readonly IEnumerable<IWorkflowTask> _workers;

        public WorkerService(
            IWorkflowTaskCoordinator workflowTaskCoordinator,
            IEnumerable<IWorkflowTask> workers)
        {
            _workflowTaskCoordinator = workflowTaskCoordinator;
            _workers = workers;
        }

        protected override System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var workerSettings = new WorkflowTaskExecutorConfiguration();
            workerSettings.BatchSize = 5;
            foreach (var worker in _workers)
            {
                _workflowTaskCoordinator.RegisterWorker(worker, workerSettings);
            }
            return _workflowTaskCoordinator.Start();
        }
    }
}
