# Netflix Conductor Client SDK

`conductor-csharp` repository provides the client SDKs to build Task Workers and Clients in C#

## Quick Start
1. [Get Secrets](#Get-Secrets)
2. [Write workers](#Write-workers)
3. [Run workers](#Run-workers)
4. [Worker Configurations](#Worker-Configurations)
5. [Starting workflow](#Starting-workflow)

### Get Secrets
Executing workflow or polling a task from a playground requires keyId and keySecret.
Please follow [guide](https://orkes.io/content/docs/codelab/helloworld#application-permissions) to provision one for your application.

### Write workers  

```
 internal class MyWorkflowTask : IWorkflowTask
    {
        public MyWorkflowTask(){}

        public string TaskType => "test_ctask";
        public int? Priority => null;

        public async Task<TaskResult> Execute(Conductor.Client.Models.Task task, CancellationToken token)
        {
           Dictionary<string, object> newOutput = new Dictionary<string, object>();
           newOutput.Add("output", "1");
           return task.Completed(task.OutputData.MergeValues(newOutput));
        }
    }

 internal class MyWorkflowTask2 : IWorkflowTask
    {
        public MyWorkflowTask2(){}

        public string TaskType => "test_ctask2";
        public int? Priority => null;

        public async Task<TaskResult> Execute(Conductor.Client.Models.Task task, CancellationToken token)
        {
           Dictionary<string, object> newOutput = new Dictionary<string, object>();
           //Reuse the existing code written in C#
           newOutput.Add("output", "success");
           return task.Completed(task.OutputData.MergeValues(newOutput));
        }
    }
```

### Run workers
Create main method that does the following:
1. Search for package called [conductor-csharp](https://www.nuget.org/packages/conductor-csharp/) in microsoft nuget package manager and install it as dependency. If you are planning to run worker then [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting/) is also required.
2. Add your workers
```
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

namespace TestOrkesSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            new HostBuilder()
                 .ConfigureServices((ctx, services) =>
                 {
                    // First argument is optional headers which client wasnt to pass.
                     Configuration configuration = new Configuration(new ConcurrentDictionary<string, string>(), 
                         "keyId",
                         "keySecret");
                     services.AddConductorWorker(configuration);
                     services.AddConductorWorkflowTask<MyWorkflowTask>();
                     services.AddHostedService<WorkflowsWorkerService>();
                 })
                 .ConfigureLogging(logging =>
                 {
                     logging.SetMinimumLevel(LogLevel.Debug);
                     logging.AddConsole();
                 })
                 .RunConsoleAsync();
            Console.ReadLine();
        }
    }

    internal class MyWorkflowTask : IWorkflowTask
    {
        public MyWorkflowTask() { }

        public string TaskType => "my_ctask";
        public int? Priority => null;

        public async Task<TaskResult> Execute(Conductor.Client.Models.Task task, CancellationToken token)
        {
            Dictionary<string, object> newOutput = new Dictionary<string, object>();
            newOutput.Add("output", 1);
            return task.Completed(task.OutputData.MergeValues(newOutput));
        }
    }
}
```

Save above code with workers code in Program.cs and run it using consoleApplication. Alternatively it can also be hosted as windows service.

3. Start the workers to poll for work
```
    internal class WorkflowsWorkerService : BackgroundService
    {
        private readonly IWorkflowTaskCoordinator workflowTaskCoordinator;
        private readonly IEnumerable<IWorkflowTask> workflowTasks;

        public WorkflowsWorkerService(
            IWorkflowTaskCoordinator workflowTaskCoordinator,
            IEnumerable<IWorkflowTask> workflowTasks
        )
        {
            this.workflowTaskCoordinator = workflowTaskCoordinator;
            this.workflowTasks = workflowTasks;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            foreach (var worker in workflowTasks)
            {
                workflowTaskCoordinator.RegisterWorker(worker);
            }
            // start all the workers so that it can poll for the tasks
            await workflowTaskCoordinator.Start();
        }
    }
```

### Worker Configurations
Worker configuration is handled via Configuration object passed when initializing TaskHandler.
```
Configuration configuration = 
    new Configuration(new ConcurrentDictionary<string, string>(), "KEY", "SECRET", "https://play.orkes.io/");
```

### Registering and starting the workflow using SDK.

Below is the code snippet that shows how to register a simple workflow and start execution:

```
IDictionary<string, string> optionalHeaders = new ConcurrentDictionary<string, string>();
Configuration configuration = new Configuration(optionalHeaders, "keyId", "keySecret");

//Create task definition
MetadataResourceApi metadataResourceApi = new MetadataResourceApi(configuration);
TaskDef taskDef = new TaskDef(name: "test_task");
taskDef.OwnerEmail = "test@test.com";
metadataResourceApi.RegisterTaskDef(new List<TaskDef>() { taskDef});

//Create workflow definition
WorkflowDef workflowDef = new WorkflowDef();
workflowDef.Name = "test_workflow";
workflowDef.OwnerEmail = "test@test.com";
workflowDef.SchemaVersion = 2;

WorkflowTask workflowTask = new WorkflowTask();
workflowTask.Type = "HTTP";
workflowTask.Name = "test_"; //Same as registered task definition.
IDictionary<string, string> requestParams = new Dictionary<string, string>();
requestParams.Add("uri", "https://www.google.com"); //adding a key/value using the Add() method
requestParams.Add("method", "GET");
Dictionary<string, object> request = new Dictionary<string, object>();
request.Add("http_request", requestParams);
workflowTask.InputParameters = request;
workflowDef.Tasks = new List<WorkflowTask>() { workflowTask };
//Run a workflow
WorkflowResourceApi workflowResourceApi = new WorkflowResourceApi(configuration);
Dictionary<string, Object> input = new Dictionary<string, Object>();
//Fill the input map which workflow consumes.
workflowResourceApi.StartWorkflow("test_workflow", input, 1);
Console.ReadLine();
```
Please see [Conductor.Api](https://github.com/conductor-sdk/conductor-csharp/tree/main/Api) for the APIs.