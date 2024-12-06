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
using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;

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
                var host = WorkflowTaskHost.CreateWorkerHost(Microsoft.Extensions.Logging.LogLevel.Information);
                await host.StartAsync();
                Thread.Sleep(40000);
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
