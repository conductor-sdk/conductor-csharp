using System.Collections;
using Conductor.Client;
using Conductor.Client.Authentication;
using Conductor.Client.Extensions;
using csharp.examples;
using Microsoft.Extensions.Logging;

namespace csharp_examples;

public class Runner
{
    /// <summary>
    ///     Running multiple task as background services
    /// </summary>
    public async void StartTasks()
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
                Console.WriteLine(e);
                throw;
            }
        }

        while (true) Thread.Sleep(TimeSpan.FromDays(1));    
    }
}