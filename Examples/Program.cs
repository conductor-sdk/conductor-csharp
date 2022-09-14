using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Conductor.Client.Models;
using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;

using Task = System.Threading.Tasks.Task;
using Conductor.Client;
using System.Collections.Concurrent;
using Conductor.Api;

namespace TestOrkesSDK
{
    class SDK
    {
        [Obsolete]
        static void Main(string[] args)
        {
            Configuration configuration = new Configuration(new ConcurrentDictionary<string, string>(), null, null,
                "http://localhost:8080/");
            //Create task definition
            MetadataResourceApi metadataResourceApi = new MetadataResourceApi(configuration);
            TaskDef taskDef = new TaskDef(name: "simple_task_0", ownerEmail:"test@orkes.io");
            taskDef.OwnerEmail = "test@orkes.io";
            metadataResourceApi.RegisterTaskDef(new List<TaskDef>() { taskDef});

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
            metadataResourceApi.UpdateWorkflowDefinitions(new List<WorkflowDef>() { workflowDef});

            //Start workflow
            WorkflowResourceApi workflowResourceApi = new WorkflowResourceApi(configuration);
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