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
        private int concurrentWorkers;
        private IServiceProvider serviceProvider;
        private ILogger<WorkflowTaskCoordinator> logger;
        private HashSet<Type> workerDefinitions = new HashSet<Type>();
        private IReadableConfiguration configuration;
        private ConductorAuthTokenClient conductorAuthTokenClient;

        public WorkflowTaskCoordinator(IServiceProvider serviceProvider,
            ILogger<WorkflowTaskCoordinator> logger,
            IReadableConfiguration configuration,
            ConductorAuthTokenClient conductorAuthTokenClient)
         {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            concurrentWorkers = configuration.ConcurrentWorkers;
            this.configuration = configuration;
            this.conductorAuthTokenClient = conductorAuthTokenClient;

        }

        public async Task Start()
        {
            logger.LogInformation("Starting WorkflowCoordinator");
            if ( !string.IsNullOrEmpty(this.configuration.keyId) && !string.IsNullOrEmpty(this.configuration.keySecret))
            {
                this.configuration.AccessToken = this.conductorAuthTokenClient.getToken(this.configuration.BasePath + "/token", this.configuration.keyId,
                                                                 this.configuration.keySecret);
            }
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
