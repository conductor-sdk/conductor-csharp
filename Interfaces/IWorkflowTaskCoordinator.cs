using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conductor.Client.Interfaces
{
    public interface IWorkflowTaskCoordinator
    {
        Task Start();
        void RegisterWorker<T>(T task) where T : IWorkflowTask;
    }
}
