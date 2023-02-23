using Conductor.Api;
using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using System;

namespace Conductor.Client.Worker
{
    internal class ConductorWorkerRestClient : IConductorWorkerRestClient
    {
        private TaskResourceApi _client;
        public ConductorWorkerRestClient(IServiceProvider serviceProvider)
        {
            OrkesApiClient apiClient = serviceProvider.GetService(typeof(OrkesApiClient)) as OrkesApiClient;
            _client = apiClient.GetClient<TaskResourceApi>();
        }

        public Task PollTask(string taskType, string workerId, string domain)
        {
            return _client.Poll(taskType, workerId, domain);
        }

        public string UpdateTask(TaskResult result)
        {
            return _client.UpdateTask(result);
        }
    }
}
