using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Conductor.Client.Worker
{
    public class WorkflowTaskCoordinator : IWorkflowTaskCoordinator
    {
        private readonly ILogger<WorkflowTaskCoordinator> _logger;
        private readonly ILogger<WorkflowTaskExecutor> _logger2;
        private readonly HashSet<IWorkflowTaskExecutor> _workers;

        private readonly IConductorWorkerClient _client;

        public WorkflowTaskCoordinator(ILogger<WorkflowTaskCoordinator> logger, ILogger<WorkflowTaskExecutor> logger2, IConductorWorkerClient client)
        {
            _logger = logger;
            _workers = new HashSet<IWorkflowTaskExecutor>();
            _client = client;
            _logger2 = logger2;
        }

        public async Task Start()
        {
            _logger.LogDebug("Starting workers...");
            List<Task> runningWorkers = new List<Task>();
            foreach (var worker in _workers)
            {
                var runningWorker = worker.Start();
                runningWorkers.Add(runningWorker);
            }
            _logger.LogDebug("Started all workers");
            await Task.WhenAll(runningWorkers);
        }

        public void RegisterWorker(IWorkflowTask worker, WorkerSettings workerSettings)
        {
            var workflowTaskExecutor = new WorkflowTaskExecutor(_logger2, _client, worker, workerSettings);
            _workers.Add(workflowTaskExecutor);
        }
    }
}
