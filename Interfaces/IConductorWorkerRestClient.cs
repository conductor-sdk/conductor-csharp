using Conductor.Client.Models;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IConductorWorkerRestClient
    {
        Task<Models.Task> PollTask(string taskType, string workerId, string domain);
        Task<string> UpdateTask(TaskResult result);
    }
}
