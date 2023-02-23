using Conductor.Client.Models;

namespace Conductor.Client.Interfaces
{
    public interface IConductorWorkerRestClient
    {
        Task PollTask(string taskType, string workerId, string domain);
        string UpdateTask(TaskResult result);
    }
}
