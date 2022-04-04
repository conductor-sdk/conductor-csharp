using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conductor.Client.Worker
{
    internal class WorkflowTaskCoordinator : IWorkflowTaskCoordinator
    {
        private int concurrentWorkers;
        private IServiceProvider serviceProvider;
        private ILogger<WorkflowTaskCoordinator> logger;
        private HashSet<Type> workerDefinitions = new HashSet<Type>();
        
        public WorkflowTaskCoordinator(IServiceProvider serviceProvider,
            ILogger<WorkflowTaskCoordinator> logger,
            IOptions<ConductorClientSettings> conductorClientSettings)
         {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            concurrentWorkers = conductorClientSettings.Value.ConcurrentWorkers;
        }

        public async Task Start(string test=null)
        {
            logger.LogInformation("Starting WorkflowCoordinator");

            var pollers = new List<Task>();
            for (var i = 0; i < concurrentWorkers; i++)
            {
                var executor = serviceProvider.GetService(typeof(IWorkflowTaskExecutor)) as IWorkflowTaskExecutor;
                pollers.Add(executor.StartPoller(workerDefinitions.ToList()));
            }

            await Task.WhenAll(pollers);
        }

        public void RegisterWorker<T>(T task) where T : IWorkflowTask
        {
            workerDefinitions.Add(task.GetType());
        }
    }
}
