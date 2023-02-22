using Conductor.Api;
using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using System.Threading.Tasks;


namespace Conductor.Client.Worker
{
    internal class ConductorWorkerRestClient : IConductorWorkerRestClient
    {
        private TaskResourceApi _client;
        public ConductorWorkerRestClient(OrkesApiClient apiClient)
        {
            _client = apiClient.GetClient<TaskResourceApi>();
        }

        public Models.Task PollTask(string taskType, string workerId, string domain)
        {
            return _client.Poll(taskType, workerId, domain);
        }

        public string UpdateTask(TaskResult result)
        {
            return _client.UpdateTask(result);
        }
    }
}
