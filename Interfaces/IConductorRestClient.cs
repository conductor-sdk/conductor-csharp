using Conductor.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IConductorRestClient
    {
        Task<Models.Task> PollTask(string taskType, string workerId, string domain);
        Task<string> UpdateTask(TaskResult result);
    }
}
