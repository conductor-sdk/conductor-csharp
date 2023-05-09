using Conductor.Client.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Conductor.Client.Extensions
{
    public class WorkflowTaskHost
    {
        public static IHost CreateWorkerHost(LogLevel logLevel = LogLevel.Information)
        {
            return CreateWorkerHost(ApiExtensions.GetConfiguration(), logLevel);
        }

        public static IHost CreateWorkerHost(Configuration configuration, LogLevel logLevel = LogLevel.Information)
        {
            return CreateWorkerHost(configuration, logLevel);
        }

        public static IHost CreateWorkerHost<T>(LogLevel logLevel = LogLevel.Information, params T[] workers) where T : IWorkflowTask
        {
            return CreateWorkerHost(ApiExtensions.GetConfiguration(), logLevel, workers);
        }

        public static IHost CreateWorkerHost<T>(Configuration configuration, LogLevel logLevel = LogLevel.Information, params T[] workers) where T : IWorkflowTask
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
                            logging.SetMinimumLevel(logLevel);
                            logging.AddConsole();
                        }
                ).Build();
        }
    }
}
