using Conductor.Client.Worker;
using Microsoft.Extensions.Hosting;
using Tests.Worker;

namespace Tests.Util
{
    public class WorkerUtil
    {
        private static IHost _host = null;

        static WorkerUtil()
        {
            _host = WorkflowTaskHost.CreateWorkerHost(
                ApiUtil.GetConfiguration(),
                new SimpleWorker()
            );
        }

        public static IHost GetWorkerHost()
        {
            return _host;
        }
    }
}