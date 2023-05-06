using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Conductor.Client.Worker
{
    public static class WorkflowTaskHost
    {
        public static IHost CreateWorkerHost(Configuration configuration, LogLevel logLevel = LogLevel.Information)
        {
            return new HostBuilder()
                .ConfigureServices(
                    (ctx, services) =>
                        {
                            services.AddConductorWorker(configuration);
                            services.WithHostedService();
                        }
                ).ConfigureLogging(
                    logging =>
                        {
                            logging.SetMinimumLevel(logLevel);
                            logging.AddConsole();
                        }
                ).Build();
        }

        public static IHost CreateWorkerHost<T>(Configuration configuration, params T[] workers) where T : IWorkflowTask
        {
            return new HostBuilder()
                .ConfigureServices(
                    (ctx, services) =>
                        {
                            services.AddConductorWorker(configuration);
                            foreach (var worker in workers)
                            {
                                services.AddConductorWorkflowTask(worker);
                            }
                            services.WithHostedService();
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