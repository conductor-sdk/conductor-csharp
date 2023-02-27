using Conductor.Client.Interfaces;
using Conductor.Client.Worker;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Threading;
using System;

namespace Tests.Util
{
    public class WorkerService : BackgroundService
    {
        private readonly IWorkflowTaskCoordinator _workflowTaskCoordinator;
        private readonly IEnumerable<IWorkflowTask> _workers;
        private readonly IConductorWorkerClient _client;
        private readonly WorkerSettings _workerSettings;

        public WorkerService(
            IWorkflowTaskCoordinator workflowTaskCoordinator,
            IEnumerable<IWorkflowTask> workers)
        {
            _workflowTaskCoordinator = workflowTaskCoordinator;
            _workers = workers;
            _workerSettings = new WorkerSettings();
        }

        protected override System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            foreach (var worker in _workers)
            {
                _workflowTaskCoordinator.RegisterWorker(worker, _workerSettings);
            }
            return _workflowTaskCoordinator.Start();
        }
    }
}
