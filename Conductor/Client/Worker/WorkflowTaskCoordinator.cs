using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conductor.Client.Worker
{
    internal class WorkflowTaskCoordinator : IWorkflowTaskCoordinator
    {
        private readonly ILogger<WorkflowTaskCoordinator> _logger;

        private readonly ILogger<WorkflowTaskExecutor> _loggerWorkflowTaskExecutor;
        private readonly ILogger<WorkflowTaskMonitor> _loggerWorkflowTaskMonitor;
        private readonly HashSet<IWorkflowTaskExecutor> _workers;
        private readonly IWorkflowTaskClient _client;

        public WorkflowTaskCoordinator(IWorkflowTaskClient client, ILogger<WorkflowTaskCoordinator> logger, ILogger<WorkflowTaskExecutor> loggerWorkflowTaskExecutor, ILogger<WorkflowTaskMonitor> loggerWorkflowTaskMonitor)
        {
            _logger = logger;
            _client = client;
            _workers = new HashSet<IWorkflowTaskExecutor>();
            _loggerWorkflowTaskExecutor = loggerWorkflowTaskExecutor;
            _loggerWorkflowTaskMonitor = loggerWorkflowTaskMonitor;
        }

        public async Task Start()
        {
            _logger.LogDebug("Starting workers...");
            var runningWorkers = new List<Task>();
            foreach (var worker in _workers)
            {
                var runningWorker = worker.Start();
                runningWorkers.Add(runningWorker);
            }
            _logger.LogDebug("Started all workers");
            await Task.WhenAll(runningWorkers);
        }

        public void RegisterWorker(IWorkflowTask worker)
        {
            var workflowTaskMonitor = new WorkflowTaskMonitor(_loggerWorkflowTaskMonitor);
            var workflowTaskExecutor = new WorkflowTaskExecutor(
                _loggerWorkflowTaskExecutor,
                _client,
                worker,
                worker.WorkerSettings,
                workflowTaskMonitor
            );
            _workers.Add(workflowTaskExecutor);
        }
    }
}
