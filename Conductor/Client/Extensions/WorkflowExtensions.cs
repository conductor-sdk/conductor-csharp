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
using Conductor.Api;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using conductor.csharp.Client.Extensions;

namespace Conductor.Client.Extensions
{
    public class WorkflowExtensions
    {
        private static int RETRY_ATTEMPT_LIMIT = 3;
        private static ILogger _logger = ApplicationLogging.CreateLogger<WorkflowExtensions>();

        public static async Task<ConcurrentBag<string>> StartWorkflows(WorkflowResourceApi workflowClient, Models.StartWorkflowRequest startWorkflowRequest, int maxAllowedInParallel, int total)
        {
            var workflowIds = new ConcurrentBag<string>();
            await StartWorkflowBatch(workflowClient, startWorkflowRequest, total % maxAllowedInParallel, workflowIds);
            for (int i = 1; i * maxAllowedInParallel <= total; i += 1)
            {
                await StartWorkflowBatch(workflowClient, startWorkflowRequest, maxAllowedInParallel, workflowIds);
            }
            _logger.LogInformation($"Started {workflowIds.Count} workflows");
            return workflowIds;
        }

        public static async Task<ConcurrentBag<Models.WorkflowStatus>> GetWorkflowStatusList(WorkflowResourceApi workflowClient, int maxAllowedInParallel, params string[] workflowIds)
        {
            var workflowStatusList = new ConcurrentBag<Models.WorkflowStatus>();
            for (int index = 0; index < workflowIds.Length; index += maxAllowedInParallel)
            {
                await GetWorkflowStatusBatch(workflowClient, workflowStatusList, index, index + maxAllowedInParallel, workflowIds);
            }
            _logger.LogInformation($"Got ${workflowStatusList.Count} workflow statuses");
            return workflowStatusList;
        }

        private static async Task GetWorkflowStatusBatch(WorkflowResourceApi workflowClient, ConcurrentBag<Models.WorkflowStatus> workflowStatusList, int startIndex, int finishIndex, params string[] workflowIds)
        {
            var threads = new List<Task>();
            for (int index = Math.Max(0, startIndex); index < Math.Min(workflowIds.Length, finishIndex); index += 1)
            {
                var workflowId = workflowIds[index];
                threads.Add(Task.Run(() => GetWorkflowStatus(workflowClient, workflowStatusList, workflowId)));
            }
            await Task.WhenAll(threads);
        }

        private static async Task StartWorkflowBatch(WorkflowResourceApi workflowClient, Models.StartWorkflowRequest startWorkflowRequest, int quantity, ConcurrentBag<string> workflowIds)
        {
            var threads = new List<Task>();
            for (int counter = 0; counter < quantity; counter += 1)
            {
                threads.Add(Task.Run(() => StartWorkflow(workflowClient, startWorkflowRequest, workflowIds)));
            }
            await Task.WhenAll(threads);
        }

        private static void GetWorkflowStatus(WorkflowResourceApi workflowClient, ConcurrentBag<Models.WorkflowStatus> workflowStatusList, string workflowId)
        {
            for (int attempt = 0; attempt < RETRY_ATTEMPT_LIMIT; attempt += 1)
            {
                try
                {
                    workflowStatusList.Add(workflowClient.GetWorkflowStatusSummary(workflowId));
                    return;
                }
                catch (ApiException e)
                {
                    _logger.LogError($"Failed to get workflow status, reason: {e}");
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1 << attempt));
                }
            }
        }

        private static void StartWorkflow(WorkflowResourceApi workflowClient, Models.StartWorkflowRequest startWorkflowRequest, ConcurrentBag<string> workflowIds)
        {
            for (int attempt = 0; attempt < RETRY_ATTEMPT_LIMIT; attempt += 1)
            {
                try
                {
                    workflowIds.Add(workflowClient.StartWorkflow(startWorkflowRequest));
                    return;
                }
                catch (ApiException e)
                {
                    _logger.LogError($"Failed to start workflow, reason: {e}");
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1 << attempt));
                }
            }
        }
    }
}