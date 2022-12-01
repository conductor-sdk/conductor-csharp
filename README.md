# Netflix Conductor C# SDK

The `conductor-csharp` repository provides the client SDKs to build task workers in Go.

Building the task workers in C# mainly consists of the following steps:
1. Get Secrets
2. Write Workers
3. Run Workers
4. Worker Configurations
Building the task workers in C# mainly consists of the following steps:

1. Setup conductor-csharp package
2. Create and run task workers
3. Create workflows using code
   
### Setup Conductor C# Package​

* Create a folder to build your package
```csharp
// TODO
```

## Configurations

### Authentication Settings (Optional)
Configure the authentication settings if your Conductor server requires authentication.
* keyId: Key for authentication.
* keySecret: Secret for the key.

```csharp
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
            // Start all the workers so that they can poll for the tasks
            await workflowTaskCoordinator.Start();
        }
    }
// TODO
authenticationSettings := settings.NewAuthenticationSettings(
  "keyId",
  "keySecret",
)
```

## Worker Configurations
Worker configuration is handled via the Configuration object passed when initializing TaskHandler.
### Access Control Setup
See [Access Control](https://orkes.io/content/docs/getting-started/concepts/access-control) for more details on role-based access control with Conductor and generating API keys for your environment.

### Configure API Client
```csharp
// TODO
apiClient := client.NewAPIClient(
    settings.NewAuthenticationSettings(
        KEY,
        SECRET,
    ),
    settings.NewHttpSettings(
        "https://play.orkes.io",
    ),
)
```

## Registering and Starting Workflow using SDK

Below is the code snippet that shows how to register a simple workflow and start execution:
### Setup Logging

```csharp
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

//Fill in the input map that workflow consumes.
workflowResourceApi.StartWorkflow("test_workflow", input, 1);
Console.ReadLine();
// TODO
// SDK uses [logrus](https://github.com/sirupsen/logrus) for logging.
func init() {
	log.SetFormatter(&log.TextFormatter{})
	log.SetOutput(os.Stdout)
	log.SetLevel(log.DebugLevel)
}
```

### Next: [Create and run task workers](/docs/readme/workers.md)
