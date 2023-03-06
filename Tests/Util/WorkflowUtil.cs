using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Models;
using Conductor.Definition;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System;

namespace Tests.Util
{
    public class WorkflowUtil
    {
        private static int RETRY_ATTEMPT_LIMIT = 5;
        public static async System.Threading.Tasks.Task<ConcurrentBag<string>> StartWorkflows(WorkflowResourceApi workflowClient, ConductorWorkflow workflow, int maxAllowedInParallel, int total)
        {
            var workflowIds = new ConcurrentBag<string>();
            await StartWorkflowBatch(workflowClient, workflow, total % maxAllowedInParallel, workflowIds);
            for (int i = 1; i * maxAllowedInParallel <= total; i += 1)
            {
                await StartWorkflowBatch(workflowClient, workflow, maxAllowedInParallel, workflowIds);
            }
            Console.WriteLine($"Started {workflowIds.Count} workflows");
            return workflowIds;
        }

        public static async System.Threading.Tasks.Task<ConcurrentBag<WorkflowStatus>> GetWorkflowStatusList(WorkflowResourceApi workflowClient, int maxAllowedInParallel, params string[] workflowIds)
        {
            var workflowStatusList = new ConcurrentBag<WorkflowStatus>();
            for (int index = 0; index < workflowIds.Length; index += maxAllowedInParallel)
            {
                await GetWorkflowStatusBatch(workflowClient, workflowStatusList, workflowIds, index, index + maxAllowedInParallel);
            }
            Console.WriteLine($"Got ${workflowStatusList.Count} workflow statuses");
            return workflowStatusList;
        }

        private static async System.Threading.Tasks.Task GetWorkflowStatusBatch(WorkflowResourceApi workflowClient, ConcurrentBag<WorkflowStatus> workflowStatusList, string[] workflowIds, int startIndex, int finishIndex)
        {
            var threads = new List<System.Threading.Tasks.Task>();
            for (int i = Math.Max(0, startIndex); i < Math.Min(workflowIds.Length, finishIndex); i += 1)
            {
                int copy = i;
                threads.Add(
                    System.Threading.Tasks.Task.Run(
                        () => GetWorkflowStatus(workflowClient, workflowStatusList, workflowIds, copy)));
            }
            await System.Threading.Tasks.Task.WhenAll(threads);
        }

        private static async System.Threading.Tasks.Task StartWorkflowBatch(WorkflowResourceApi workflowClient, ConductorWorkflow workflow, int quantity, ConcurrentBag<string> workflowIds)
        {
            List<System.Threading.Tasks.Task> threads = new List<System.Threading.Tasks.Task>();
            var startWorkflowRequest = workflow.GetStartWorkflowRequest();
            for (int counter = 0; counter < quantity; counter += 1)
            {
                threads.Add(
                    System.Threading.Tasks.Task.Run(
                        () => StartWorkflow(workflowClient, startWorkflowRequest, workflowIds)));
            }
            await System.Threading.Tasks.Task.WhenAll(threads);
        }

        private static void GetWorkflowStatus(WorkflowResourceApi workflowClient, ConcurrentBag<WorkflowStatus> workflowStatusList, string[] workflowIds, int index)
        {
            for (int attempt = 0; attempt < RETRY_ATTEMPT_LIMIT; attempt += 1)
            {
                try
                {
                    workflowStatusList.Add(workflowClient.GetWorkflowStatusSummary(workflowIds[index]));
                    return;
                }
                catch (ApiException e)
                {
                    Console.WriteLine($"Failed to get workflow status, reason: {e}");
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
        }

        private static void StartWorkflow(WorkflowResourceApi workflowClient, StartWorkflowRequest startWorkflowRequest, ConcurrentBag<string> workflowIds)
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
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
        }
    }
}