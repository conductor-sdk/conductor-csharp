using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conductor.Interfaces
{
    public interface IWorkflowTaskExecutor
    {
        Task StartPoller(List<Type> workerDefinitions);
    }
}
