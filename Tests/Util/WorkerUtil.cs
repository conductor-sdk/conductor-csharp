using Conductor.Client.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Tests.Worker;

namespace Tests.Util
{
    public class WorkerUtil
    {
        public static IHost GetWorkerHost()
        {
            return new HostBuilder()
                .ConfigureServices(
                    (ctx, services) =>
                        {
                            services.AddConductorWorker();
                            services.AddConductorWorkflowTask<SimpleWorker>();
                            services.WithHostedService<WorkerService>();
                        }
                ).ConfigureLogging(
                    logging =>
                        {
                            logging.SetMinimumLevel(LogLevel.Debug);
                            logging.AddConsole();
                        }
                ).Build();
        }
    }
}