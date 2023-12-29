using Conductor.Client.Authentication;
using Conductor.Client.Extensions;
using Conductor.Client;
using csharp.examples;
using Microsoft.Extensions.Logging;

namespace csharp_examples
{
    public class Runner
    {

        /// <summary>
        /// Running multiple task as background services
        /// </summary>
        public async void RunMultiSimpleTask()
        {
            var configuration = new Configuration()
            {
                AuthenticationSettings = new OrkesAuthenticationSettings("8bea4294-e16d-4437-85f0-327c29a1378c", "skZjhMzNNNm9EJDLLxD6JKYs6ADHqQ0xh1iUCqm6mOoCktHn")
            };
            var host = WorkflowTaskHost.CreateWorkerHost(configuration, LogLevel.Information, new SimpleTask1());
            var ct = new CancellationTokenSource();
            await host.StartAsync(ct.Token);
            var host1 = WorkflowTaskHost.CreateWorkerHost(configuration, LogLevel.Information, new SimpleTask2());
            var ct1 = new CancellationTokenSource();
            await host1.StartAsync(ct.Token);
            Thread.Sleep(TimeSpan.FromSeconds(100)); // after 100 seconds will stop the service
        }

        /// <summary>
        /// Run single task as background service
        /// </summary>
        public async void RunSimpleTask()
        {
            var configuration = new Configuration()
            {
                AuthenticationSettings = new OrkesAuthenticationSettings("8bea4294-e16d-4437-85f0-327c29a1378c", "skZjhMzNNNm9EJDLLxD6JKYs6ADHqQ0xh1iUCqm6mOoCktHn")
            };

            var host = WorkflowTaskHost.CreateWorkerHost(configuration, LogLevel.Information, new SimpleTask1());
            var ct = new CancellationTokenSource();
            await host.StartAsync();
            Thread.Sleep(TimeSpan.FromSeconds(100)); // after 100 seconds will stop the service
        }
    }
}
