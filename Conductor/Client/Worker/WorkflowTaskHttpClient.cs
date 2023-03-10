using Conductor.Api;
using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using System.Collections.Generic;

namespace Conductor.Client.Worker
{
    public class WorkflowTaskHttpClient : IWorkflowTaskClient
    {
        private readonly TaskResourceApi _client;
        public WorkflowTaskHttpClient(Configuration configuration)
        {
            _client = configuration.GetClient<TaskResourceApi>();
        }

        public List<Task> PollTask(string taskType, string workerId, string domain, int count = 1)
        {
            return _client.BatchPoll(taskType, workerId, domain, count);
        }

        public string UpdateTask(TaskResult result)
        {
            return _client.UpdateTask(result);
        }
    }
}
