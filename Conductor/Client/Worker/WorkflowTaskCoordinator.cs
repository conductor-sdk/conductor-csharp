using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conductor.Client.Worker
{
    internal class WorkflowTaskCoordinator : IWorkflowTaskCoordinator
    {
        private int _concurrentWorkers;
        private ILogger<WorkflowTaskCoordinator> _logger;
        private IWorkflowTaskExecutor _workflowTaskExecutor;
        private HashSet<IWorkflowTask> _workerDefinitions;

        public WorkflowTaskCoordinator(IServiceProvider serviceProvider, ILogger<WorkflowTaskCoordinator> logger)
        {
            _logger = logger;
            _workerDefinitions = new HashSet<IWorkflowTask>();
            _workflowTaskExecutor = serviceProvider.GetService(typeof(IWorkflowTaskExecutor)) as IWorkflowTaskExecutor;
        }

        public async Task Start()
        {
            _logger.LogInformation("Starting WorkflowCoordinator");
            var pollers = new List<Task>();
            for (var i = 0; i < _concurrentWorkers; i++)
            {
                pollers.Add(_workflowTaskExecutor.StartPoller(_workerDefinitions.ToList()));
            }
            await Task.WhenAll(pollers);
        }

        public void RegisterWorker(IWorkflowTask task)
        {
            _workerDefinitions.Add(task);
        }
    }
}
