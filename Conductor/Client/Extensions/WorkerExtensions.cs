using Conductor.Client.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Conductor.Client.Extensions
{
    public class WorkerExtensions
    {
        private static IHost _host = null;

        static WorkerExtensions()
        {
            _host = WorkflowTaskHost.CreateWorkerHost(
                ApiExtensions.GetConfiguration(), LogLevel.Trace
            );
        }

        public static IHost GetWorkerHost()
        {
            return _host;
        }
    }
}
