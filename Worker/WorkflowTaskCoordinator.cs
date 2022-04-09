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
        private ConductorWorkerClientConfiguration conductorClientSetting;
        private ConductorAuthTokenClient conductorAuthTokenClient;

        public WorkflowTaskCoordinator(IServiceProvider serviceProvider,
            ILogger<WorkflowTaskCoordinator> logger,
            IOptions<ConductorWorkerClientConfiguration> conductorClientSettings,
            ConductorAuthTokenClient conductorAuthTokenClient)
         {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            concurrentWorkers = conductorClientSettings.Value.ConcurrentWorkers;
            conductorClientSetting = conductorClientSettings.Value;
            this.conductorAuthTokenClient = conductorAuthTokenClient;

        }

        public async Task Start()
        {
            logger.LogInformation("Starting WorkflowCoordinator");
            if (this.conductorClientSetting.AuthenticationConfiguration != null 
                && !string.IsNullOrEmpty(this.conductorClientSetting.AuthenticationConfiguration.keyId)
                && !string.IsNullOrEmpty(this.conductorClientSetting.AuthenticationConfiguration.keySecret))
            {
                this.conductorClientSetting.Token = this.conductorAuthTokenClient.PostForToken(this.conductorClientSetting.ServerUrl + "/token", this.conductorClientSetting.AuthenticationConfiguration.keyId,
                                                                 this.conductorClientSetting.AuthenticationConfiguration.keySecret).Result;
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
