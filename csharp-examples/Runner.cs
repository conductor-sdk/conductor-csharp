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
using System.Collections;
using conductor.csharp.Client.Extensions;
using Conductor.Client;
using Conductor.Client.Authentication;
using Conductor.Client.Extensions;
using csharp.examples;
using Microsoft.Extensions.Logging;

namespace csharp_examples;

public class Runner
{
    public readonly ILogger _logger;

    public Runner()
    {
        _logger = ApplicationLogging.CreateLogger<Runner>();
    }

    /// <summary>
    ///     Running multiple task as background services
    /// </summary>
    public async void StartTasks()
    {
        try
        {
            var key = Environment.GetEnvironmentVariable("KEY");
            var secret = Environment.GetEnvironmentVariable("SECRET");
            var url = Environment.GetEnvironmentVariable("CONDUCTOR_SERVER_URL");

            var configuration = new Configuration
            {
                BasePath = url,
                AuthenticationSettings = new OrkesAuthenticationSettings(key, secret)
            };
            var num = 5;
            for (var i = 1; i <= num; i++)
            {
                var host = WorkflowTaskHost.CreateWorkerHost(configuration, LogLevel.Information,
                    new TestWorker("csharp_task_" + i));
                var ct = new CancellationTokenSource();
                try
                {
                    await host.StartAsync(ct.Token);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    throw;
                }
            }

            while (true)
                Thread.Sleep(TimeSpan.FromDays(1));// after 1 year will stop the service

        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message}");
        }
    }
}