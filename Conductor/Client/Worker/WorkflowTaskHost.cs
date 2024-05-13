/*
 * Copyright 2024 Conductor Authors.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */
using Conductor.Client.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            return CreateWorkerHost(configuration, logLevel, workers: new IWorkflowTask[0]);
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
