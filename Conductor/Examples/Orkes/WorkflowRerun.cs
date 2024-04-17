using conductor.csharp.Client.Extensions;
using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Executor;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Conductor.Examples.Orkes
{
    public class WorkflowRerun
    {
        private readonly WorkflowExecutor _executor;
        private readonly Configuration _Config;
        private readonly MetadataResourceApi _metaDataClient;
        private readonly WorkflowResourceApi _workflowClient;
        private readonly ILogger _logger;
        private const string TASK_REFRENECE_NAME1 = "simple_task_ref1_case1_1";
        private const string TASK_REFRENECE_NAME2 = "simple_task_ref1_case1_2";
        private const string NAME = "rerun_test";

        public WorkflowRerun()
        {
            _Config = new Configuration();
            _executor = new WorkflowExecutor(_Config);
            _metaDataClient = ApiExtensions.GetClient<MetadataResourceApi>();
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _logger = ApplicationLogging.CreateLogger<WorkflowRerun>();
        }

        /// <summary>
        /// Method to register the workflow
        /// </summary>
        public void ReadAndRegisterWorkflow()
        {
            using (StreamReader file = File.OpenText("ReRunWorkflow.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                WorkflowDef workflow = (WorkflowDef)serializer.Deserialize(file, typeof(WorkflowDef));
                _logger.LogInformation($"loaded workflow {workflow}");
                _metaDataClient.UpdateWorkflowDefinitions(body: new List<WorkflowDef> { workflow }, overwrite: true);
            }
        }

        /// <summary>
        /// Method to start the workflow
        /// </summary>
        /// <returns></returns>
        public string StartWorkflow()
        {
            var startReq = new StartWorkflowRequest()
            {
                Name = NAME,
                Version = 1,
                Input = new Dictionary<string, object>() { { "case", "case1" } }
            };

            var workflowId = _executor.StartWorkflow(startReq);
            return workflowId;
        }

        /// <summary>
        /// Method to test the work flow reeun scenario
        /// </summary>
        public void WorkflowRerunTest()
        {
            // Let's load up the workflow definition from a file and register
            ReadAndRegisterWorkflow();

            var workflowId = StartWorkflow();
            _logger.LogInformation($"started workflow with id {workflowId}");

            var updateRequest = new WorkflowStateUpdate()
            {
                TaskReferenceName = TASK_REFRENECE_NAME1,
                TaskResult = new TaskResult() { Status = TaskResult.StatusEnum.COMPLETED },
            };

            var workflowRun = _workflowClient.UpdateWorkflow(workflowId, updateRequest,
            waitUntilTaskRefs: new List<string>() { TASK_REFRENECE_NAME2 }, waitForSeconds: 0);

            updateRequest.TaskReferenceName = TASK_REFRENECE_NAME2;

            workflowRun = _workflowClient.UpdateWorkflow(workflowId, updateRequest,
            waitUntilTaskRefs: new List<string>() { TASK_REFRENECE_NAME1 }, waitForSeconds: 0);

            var task = workflowRun.GetTask(taskReferenceName: TASK_REFRENECE_NAME2);

            var rerunReq = new RerunWorkflowRequest()
            {
                ReRunFromTaskId = task.TaskId
            };

            _workflowClient.Rerun(rerunReq, workflowId);
        }
    }
}