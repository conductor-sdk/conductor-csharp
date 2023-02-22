using Conductor.Client.Models;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IConductorWorkerRestClient
    {
        Models.Task PollTask(string taskType, string workerId, string domain);
        string UpdateTask(TaskResult result);
    }
}
