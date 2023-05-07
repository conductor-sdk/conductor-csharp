using Conductor.Api;
using Conductor.Client;
using Conductor.Definition;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Conductor.Client.Extensions
{
    public class WorkflowExtensions
    {
        private static int RETRY_ATTEMPT_LIMIT = 3;

        public static async Task<ConcurrentBag<string>> StartWorkflows(WorkflowResourceApi workflowClient, Models.StartWorkflowRequest startWorkflowRequest, int maxAllowedInParallel, int total)
        {
            var workflowIds = new ConcurrentBag<string>();
            await StartWorkflowBatch(workflowClient, startWorkflowRequest, total % maxAllowedInParallel, workflowIds);
            for (int i = 1; i * maxAllowedInParallel <= total; i += 1)
            {
                await StartWorkflowBatch(workflowClient, startWorkflowRequest, maxAllowedInParallel, workflowIds);
            }
            Console.WriteLine($"Started {workflowIds.Count} workflows");
            return workflowIds;
        }

        public static async Task<ConcurrentBag<Models.WorkflowStatus>> GetWorkflowStatusList(WorkflowResourceApi workflowClient, int maxAllowedInParallel, params string[] workflowIds)
        {
            var workflowStatusList = new ConcurrentBag<Models.WorkflowStatus>();
            for (int index = 0; index < workflowIds.Length; index += maxAllowedInParallel)
            {
                await GetWorkflowStatusBatch(workflowClient, workflowStatusList, workflowIds, index, index + maxAllowedInParallel);
            }
            Console.WriteLine($"Got ${workflowStatusList.Count} workflow statuses");
            return workflowStatusList;
        }

        private static async Task GetWorkflowStatusBatch(WorkflowResourceApi workflowClient, ConcurrentBag<Models.WorkflowStatus> workflowStatusList, string[] workflowIds, int startIndex, int finishIndex)
        {
            var threads = new List<Task>();
            for (int i = Math.Max(0, startIndex); i < Math.Min(workflowIds.Length, finishIndex); i += 1)
            {
                threads.Add(Task.Run(() => GetWorkflowStatus(workflowClient, workflowStatusList, workflowIds[i])));
            }
            await Task.WhenAll(threads);
        }

        private static async Task StartWorkflowBatch(WorkflowResourceApi workflowClient, Models.StartWorkflowRequest startWorkflowRequest, int quantity, ConcurrentBag<string> workflowIds)
        {
            List<Task> threads = new List<Task>();
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
                    Console.WriteLine($"Failed to get workflow status, reason: {e}");
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
                    Console.WriteLine($"Failed to start workflow, reason: {e}");
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1 << attempt));
                }
            }
        }
    }
}