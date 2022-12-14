using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using System.Threading.Tasks;
using Conductor.Api;

namespace Conductor.Client
{
    public class ConductorWorkerRestClient : IConductorWorkerRestClient
    {
        private TaskResourceApi _client;
        public ConductorWorkerRestClient(OrkesApiClient apiClient)
        {
            _client = apiClient.GetClient<TaskResourceApi>();
        }

        public Task<Models.Task> PollTask(string taskType, string workerId, string domain)
        {
            return _client.PollAsync(taskType, workerId, domain);
        }

        public Task<string> UpdateTask(TaskResult result)
        {
            return _client.UpdateTaskAsync(result);
        }
    }
}
