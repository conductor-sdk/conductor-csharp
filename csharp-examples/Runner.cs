using Conductor.Client;
using Conductor.Client.Authentication;
using Conductor.Client.Extensions;
using conductor.csharp.Client.Extensions;
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
                Thread.Sleep(TimeSpan.FromDays(1)); // after 1 year will stop the service
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message}");
        }
    }
}