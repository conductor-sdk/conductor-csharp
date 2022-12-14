using Conductor.Api;
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
        private IServiceProvider _serviceProvider;
        private ILogger<WorkflowTaskCoordinator> _logger;
        private HashSet<Type> _workerDefinitions;
        private TaskResourceApi _client;

        public WorkflowTaskCoordinator(IServiceProvider serviceProvider, ILogger<WorkflowTaskCoordinator> logger, OrkesApiClient orkesApiClient, int? concurrentWorkers = null)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _workerDefinitions = new HashSet<Type>();
            if (concurrentWorkers == null)
            {
                concurrentWorkers = 1;
            }
            _concurrentWorkers = concurrentWorkers.Value;
            _client = orkesApiClient.GetClient<TaskResourceApi>();
        }

        public async Task Start()
        {
            _logger.LogInformation("Starting WorkflowCoordinator");
            var pollers = new List<Task>();
            for (var i = 0; i < _concurrentWorkers; i++)
            {
                var executor = _serviceProvider.GetService(typeof(IWorkflowTaskExecutor)) as IWorkflowTaskExecutor;
                pollers.Add(executor.StartPoller(_workerDefinitions.ToList()));
            }
            await Task.WhenAll(pollers);
        }

        public void RegisterWorker<T>(T task) where T : IWorkflowTask
        {
            _workerDefinitions.Add(task.GetType());
        }
    }
}
