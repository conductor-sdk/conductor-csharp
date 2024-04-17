using conductor.csharp.Client.Extensions;
using Conductor.Api;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Examples.Copilot;
using Conductor.Executor;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Conductor.Examples.Orkes
{
    public class SyncUpdates
    {
        private readonly Client.Configuration _configuration;
        private readonly WorkflowExecutor executor;
        private readonly WorkflowResourceApi _workflowClient;
        private readonly ILogger _logger;

        public SyncUpdates()
        {
            _configuration = new Client.Configuration();
            executor = new WorkflowExecutor(_configuration);
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _logger = ApplicationLogging.CreateLogger<OpenAICopilot>();

            //Local testing
            //OrkesApiClient orkesApiClient = new OrkesApiClient(configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
        }
        public void SyncUpdatesTest()
        {
            // prepare and Create
            var workflow = Create_Workflow(executor);
            var startReq = new StartWorkflowRequest() { Name = workflow.Name, Version = workflow.Version };
            var workflowId = executor.StartWorkflow(startReq);

            _logger.LogInformation($"started {workflowId}");

            var task_result = new TaskResult()
            {
                Status = TaskResult.StatusEnum.COMPLETED
            };

            var state_update = new WorkflowStateUpdate()
            {
                TaskReferenceName = "wait_task_ref",
                TaskResult = task_result,
                Variables = new Dictionary<string, object>
{
{ "case", "case1" }
}
            };

            var workflowRun = _workflowClient.UpdateWorkflow(workflowId, state_update, waitForSeconds: 1,
            waitUntilTaskRefs: new List<string>() { "wait_task_ref_1", "wait_task_ref_2" });

            var last_task_ref = workflowRun.Tasks[workflowRun.Tasks.Count - 1].ReferenceTaskName;
            _logger.LogInformation($"workflow: {workflowRun.Status}, last task = {last_task_ref}");

            state_update.TaskReferenceName = last_task_ref;
            workflowRun = _workflowClient.UpdateWorkflow(workflowId, state_update, waitForSeconds: 1);

            _logger.LogInformation($"workflow: {workflowRun.Status}, last task = {last_task_ref}");
        }

        public ConductorWorkflow Create_Workflow(WorkflowExecutor executor)
        {
            var workflow = new ConductorWorkflow()
            .WithName("sync_task_variable_updates")
            .WithVersion(1).
            WithDescription("sync task variable updates");

            var http = new HttpTask("http_ref", new HttpTaskSettings() { uri = "https://orkes-api-tester.orkesconductor.com/api" });
            var wait = new WaitTask("wait_task_ref", TimeSpan.FromSeconds(1));
            var wait_case_1 = new WaitTask("wait_task_ref_1", TimeSpan.FromSeconds(1));
            var wait_case_2 = new WaitTask("wait_task_ref_2", TimeSpan.FromSeconds(1));

            var switchTask = new SwitchTask("switch_ref", "${workflow.variables.case}");
            switchTask.WithDecisionCase("case1", wait_case_1);
            switchTask.WithDecisionCase("case2", wait_case_2);

            workflow.WithTask(http)
            .WithTask(wait)
            .WithTask(switchTask);

            executor.RegisterWorkflow(workflow, true);

            return workflow;
        }
    }
}
