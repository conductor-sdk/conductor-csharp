using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conductor.Client.Worker
{
    public class WorkflowTaskCoordinator : IWorkflowTaskCoordinator
    {
        private readonly ILogger<WorkflowTaskCoordinator> _logger;
        private readonly HashSet<IWorkflowTaskExecutor> _workers;
        private readonly IWorkflowTaskClient _client;

        public WorkflowTaskCoordinator(ILogger<WorkflowTaskCoordinator> logger, IWorkflowTaskClient client)
        {
            _logger = logger;
            _client = client;
            _workers = new HashSet<IWorkflowTaskExecutor>();
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

        public void RegisterWorker(IWorkflowTaskExecutor workflowTaskExecutor)
        {
            _workers.Add(workflowTaskExecutor);
        }
    }
}
