using Conductor.Api;
using Conductor.Client.Models;
using Conductor.Definition;
using System.Collections.Generic;

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
                var startIndex = size - maxAllowedInParallel;
                var finishIndex = size;
                await GetWorkflowStatus(workflowClient, workflowStatusList, workflowIds, startIndex, finishIndex);
            }
            return workflowStatusList;
        }

        private static async System.Threading.Tasks.Task GetWorkflowStatus(WorkflowResourceApi workflowClient, List<WorkflowStatus> workflowStatusList, List<string> workflowIds, int startIndex, int finishIndex)
        {
            var runningThreads = new List<System.Threading.Tasks.Task>();
            for (int i = startIndex; i < finishIndex; i += 1)
            {
                var workflowId = workflowIds[i];
                var thread = System.Threading.Tasks.Task.Run(() =>
                    {
                        var workflowStatus = workflowClient.GetWorkflowStatusSummary(workflowId);
                        workflowStatusList.Add(workflowStatus);
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
                    var workflowId = workflowClient.StartWorkflow(startWorkflowRequest);
                    workflowIds.Add(workflowId);
                });
                startedWorkflows.Add(thread);
            }
            await System.Threading.Tasks.Task.WhenAll(startedWorkflows);
        }
    }
}