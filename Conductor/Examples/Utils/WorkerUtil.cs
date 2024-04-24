using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conductor.Examples.Utils
{
    public static class WorkerUtil
    {
        /// <summary>
        /// Method to start the background job
        /// </summary>
        /// <param name="waitHandle"></param>
        /// <param name="workers"></param>
        /// <returns></returns>
        public static async Task<bool> StartBackGroundTask(ManualResetEvent waitHandle, params IWorkflowTask[] workers)
        {
            try
            {
                var host = WorkflowTaskHost.CreateWorkerHost(Microsoft.Extensions.Logging.LogLevel.Information, workers);
                await host.StartAsync();
                Thread.Sleep(20000);
                waitHandle.Set();
                await host.StopAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in background task: {ex.Message}");
                waitHandle.Set();
                return false;
            }
        }
    }
}
