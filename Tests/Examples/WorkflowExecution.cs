using Conductor.Api;
using Conductor.Client.Authentication;
using Conductor.Client.Models;
using System;
using System.Collections.Generic;
using Tests.Util;
using Xunit;

namespace Tests.Examples
{
    public class WorkflowExecutionExampleTests : IntegrationTest
    {
        [Fact]
        public void TestWorkflowExecutionExample()
        {
            OrkesApiClient apiClient = ApiUtil.GetApiClient();
            MetadataResourceApi metadataResourceApi = apiClient.GetClient<MetadataResourceApi>();
            TaskDef taskDef = new TaskDef(name: "simple_task_0", ownerEmail: "test@orkes.io");
            taskDef.OwnerEmail = "test@orkes.io";
            metadataResourceApi.RegisterTaskDef(new List<TaskDef>() { taskDef });

            WorkflowTask workflowTask = new(name: "simple_task_0", taskReferenceName: "simple_task_0")
            {
                Type = "SIMPLE"
            };
            Dictionary<string, object> request = new Dictionary<string, object>();
            workflowTask.InputParameters = request;
            int version = 3;

            //Create workflow definition
            WorkflowDef workflowDef = new WorkflowDef(name: "new_load_test",
                tasks: new List<WorkflowTask>() { workflowTask }, version: version);
            workflowDef.OwnerEmail = "manan.bhatt@orkes.io";
            workflowDef.SchemaVersion = 2;
            metadataResourceApi.UpdateWorkflowDefinitions(new List<WorkflowDef>() { workflowDef });

            //Start workflow
            WorkflowResourceApi workflowResourceApi = apiClient.GetClient<WorkflowResourceApi>();
            String workflowId = workflowResourceApi.StartWorkflow("new_load_test", new Dictionary<string, object>(), version);
            Console.WriteLine("WorkflowId " + workflowId);

            //Terminate workflow
            workflowResourceApi.Terminate(workflowId, "Operation not supported");

            //Start worklfow
            workflowId = workflowResourceApi.StartWorkflow("new_load_test", new Dictionary<string, object>(), version);
            Console.WriteLine("WorkflowId " + workflowId);

            //Pause workflow
            workflowResourceApi.PauseWorkflow(workflowId);

            //Check Execution Status
            Workflow workflow = workflowResourceApi.GetExecutionStatus(workflowId);
            Console.WriteLine("Execution status " + workflow.Status); // PAUSED

            //Resume workflow
            workflowResourceApi.ResumeWorkflow(workflowId);

            //Check Execution Status
            workflow = workflowResourceApi.GetExecutionStatus(workflowId);
            Console.WriteLine("Execution status " + workflow.Status); // RUNNING
        }
    }
}