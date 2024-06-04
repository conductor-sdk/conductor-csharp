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
using Conductor.Client;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using Conductor.Definition.TaskType;
using Conductor.Definition;
using Conductor.Examples.Orkes.Workers;
using System;
using System.Collections.Generic;
using System.Threading;
using Conductor.Api;
using Conductor.Client.Extensions;
using Conductor.Executor;
using Task = Conductor.Client.Models.Task;

namespace Conductor.Examples
{
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public float SkuPrice { get; set; }
    }

    [WorkerTask]
    public class TaskWorkers
    {
        private readonly MetadataResourceApi _metaDataClient;
        private readonly WorkflowResourceApi _workflowClient;
        private readonly WorkflowExecutor _workflowExecutor;

        //const
        private const string WorkflowName = "Task_Workers";
        private const string WorkflowDescription = "Task workers decription";

        public TaskWorkers()
        {
            var config = new Configuration();
            _workflowExecutor = new WorkflowExecutor(config);
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _metaDataClient = ApiExtensions.GetClient<MetadataResourceApi>();

            //For local testing
            //var _orkesApiClient = new OrkesApiClient(config, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
            //_metaDataClient = _orkesApiClient.GetClient<MetadataResourceApi>();
        }

        [WorkerTask(taskType: "get_user_info", batchSize: 5, pollIntervalMs: 520, workerId: "workerId")]
        public static UserDetails GetUserInfo(string userId)
        {
            if (userId == null)
            {
                userId = "none";
            }
            return new UserDetails("user_" + userId, userId, new List<object>
{
new
{
street = "21 jump street",
city = "new york"
}
});
        }

        [WorkerTask(taskType: "save_order", batchSize: 5, pollIntervalMs: 520, workerId: "workerId")]
        public static OrderInfo SaveOrder(OrderInfo orderDetails)
        {
            orderDetails.SkuPrice = orderDetails.Quantity * orderDetails.SkuPrice;
            return orderDetails;
        }

        [WorkerTask(taskType: "process_task", batchSize: 5, pollIntervalMs: 520, workerId: "workerId")]
        public static TaskResult ProcessTask(Task task)
        {
            {
                TaskResult taskResult = task.ToTaskResult(TaskResult.StatusEnum.COMPLETED);
                taskResult.OutputData["name"] = "orkes";
                taskResult.OutputData["complex"] = new UserDetails(name: "u1", addresses: new List<object>(), userId: "5");
                taskResult.OutputData["time"] = DateTime.Now;
                return taskResult;
            }
        }

        [WorkerTask(taskType: "failure", batchSize: 5, pollIntervalMs: 520, workerId: "workerId")]
        public static void AlwaysFail()
        {
            // Raising NonRetryableException updates the task with FAILED_WITH_TERMINAL_ERROR status
            throw new InvalidOperationException("This worker task will always have a terminal failure");
        }

        [WorkerTask(taskType: "fail_but_retry", batchSize: 5, pollIntervalMs: 520, workerId: "workerId")]
        public static int FailButRetry()
        {
            var random = new Random();
            var numx = random.Next(0, 11);
            if (numx < 8)
            {
                // Raising NonRetryableException updates the task with FAILED_WITH_TERMINAL_ERROR status
                throw new Exception($"Number {numx} is less than 8. I am going to fail this task and retry");
            }
            return numx;
        }

        public void TaskWorkersFlowMain()
        {
            ConductorWorkflow workflow = new ConductorWorkflow()
            .WithName(WorkflowName)
            .WithDescription(WorkflowDescription)
            .WithVersion(1);

            workflow.WithInputParameter("userId");

            var GetUserInfo = new SimpleTask("get_user_info", "get_user_info").WithInput("userId", workflow.Input("userId"));
            GetUserInfo.Description = "Get User Info decription";
            workflow.WithTask(GetUserInfo);

            List<TaskDef> taskDefs = new List<TaskDef>()
{
new TaskDef{Description = "Get user info", Name = "GetUserinfo" },
};

            _metaDataClient.RegisterTaskDef(taskDefs);
            _metaDataClient.UpdateWorkflowDefinitions(new List<WorkflowDef>(1) { workflow });

            var testInput = new Dictionary<string, object>
{
{ "userId", "Test" }
};

            StartWorkflowRequest startWorkflowRequest = new StartWorkflowRequest()
            {
                Name = workflow.Name,
                Input = testInput,
                Version = workflow.Version,
                WorkflowDef = workflow,
                CreatedBy = Constants.OWNER_EMAIL
            };

            _workflowClient.StartWorkflow(startWorkflowRequest);
            var waitHandle = new ManualResetEvent(false);

            var backgroundTask = System.Threading.Tasks.Task.Run(async () => await Utils.WorkerUtil.StartBackGroundTask(waitHandle));
            waitHandle.WaitOne();
        }
    }
}
