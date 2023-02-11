using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTaskExecutor
    {
        Task StartPoller(List<IWorkflowTask> workerDefinitions);
    }
}
