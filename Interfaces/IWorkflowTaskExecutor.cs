using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTaskExecutor
    {
        Task StartPoller(List<Type> workerDefinitions);
    }
}
