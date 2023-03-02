using Conductor.Api;
using Conductor.Client.Models;
using Conductor.Definition;
using Conductor.Exceptions;
using System.Collections.Generic;
using System;

namespace Tests.Util
{
    public class WorkflowUtil
    {
        public static async System.Threading.Tasks.Task<List<string>> StartWorkflows(WorkflowResourceApi workflowClient, ConductorWorkflow workflow, int maxAllowedInParallel, int total)
        {
            var workflowIds = new List<string>();
            if (total % maxAllowedInParallel != 0)
            {
                await StartWorkflows(workflowClient, workflow, total % maxAllowedInParallel, workflowIds);
            }
            for (int i = 1; i * maxAllowedInParallel <= total; i += 1)
            {
                await StartWorkflows(workflowClient, workflow, maxAllowedInParallel, workflowIds);
            }
            Console.WriteLine($"Started {workflowIds.Count} workflows");
            return workflowIds;
        }

        public static async System.Threading.Tasks.Task<List<WorkflowStatus>> GetWorkflowStatus(WorkflowResourceApi workflowClient, int maxAllowedInParallel, List<string> workflowIds)
        {
            var workflowStatusList = new List<WorkflowStatus>();
            var size = workflowIds.Count;
            for (int i = 0; (i + 1) * maxAllowedInParallel <= size; i += 1)
            {
                var startIndex = i * maxAllowedInParallel;
                var finishIndex = startIndex + maxAllowedInParallel;
                await GetWorkflowStatus(workflowClient, workflowStatusList, workflowIds, startIndex, finishIndex);
            }
            if (size % maxAllowedInParallel != 0)
            {
                var startIndex = Math.Max(0, size - maxAllowedInParallel);
                var finishIndex = size;
                await GetWorkflowStatus(workflowClient, workflowStatusList, workflowIds, startIndex, finishIndex);
            }
            Console.WriteLine($"Got ${workflowStatusList.Count} workflow statuses");
            return workflowStatusList;
        }

        private static async System.Threading.Tasks.Task GetWorkflowStatus(WorkflowResourceApi workflowClient, List<WorkflowStatus> workflowStatusList, List<string> workflowIds, int startIndex, int finishIndex)
        {
            Console.WriteLine($"startIndex: {startIndex}, finishIndex: {finishIndex}, length: {workflowIds.Count}");
            var runningThreads = new List<System.Threading.Tasks.Task>();
            for (int i = startIndex; i < finishIndex; i += 1)
            {
                var workflowId = workflowIds[i];
                var thread = System.Threading.Tasks.Task.Run(() =>
                    {
                        for (int attempt = 0; attempt < 3; attempt += 1)
                        {
                            try
                            {
                                workflowStatusList.Add(workflowClient.GetWorkflowStatusSummary(workflowId));
                                break;
                            }
                            catch (ConductorApiException e)
                            {
                                Console.WriteLine($"Failed to get workflow status, reason: {e}");
                                System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1 << attempt));
                            }
                        }
                    }
                );
                runningThreads.Add(thread);
            }
            await System.Threading.Tasks.Task.WhenAll(runningThreads);
        }

        private static async System.Threading.Tasks.Task StartWorkflows(WorkflowResourceApi workflowClient, ConductorWorkflow workflow, int quantity, List<string> workflowIds)
        {
            List<System.Threading.Tasks.Task> startedWorkflows = new List<System.Threading.Tasks.Task>();
            for (int counter = 0; counter < quantity; counter += 1)
            {
                var thread = System.Threading.Tasks.Task.Run(() =>
                {
                    var startWorkflowRequest = workflow.GetStartWorkflowRequest();
                    for (int attempt = 0; attempt < 3; attempt += 1)
                    {
                        try
                        {
                            workflowIds.Add(workflowClient.StartWorkflow(startWorkflowRequest));
                            break;
                        }
                        catch (ConductorApiException e)
                        {
                            Console.WriteLine($"Failed to start workflow, reason: {e}");
                            System.Threading.Thread.Sleep(System.TimeSpan.FromSeconds(1 << attempt));
                        }
                    }
                });
                startedWorkflows.Add(thread);
            }
            await System.Threading.Tasks.Task.WhenAll(startedWorkflows);
        }
    }
}