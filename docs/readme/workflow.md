# Authoring Workflows with the C# SDK

## A simple two-step workflow

```csharp
using Conductor.Client;
using Conductor.Definition;
using Conductor.Executor;

ConductorWorkflow GetConductorWorkflow()
{
    return new ConductorWorkflow()
        .WithName("my_first_workflow")
        .WithVersion(1)
        .WithOwner("developers@orkes.io")
            .WithTask(new SimpleTask("simple_task_2", "simple_task_1"))
            .WithTask(new SimpleTask("simple_task_1", "simple_task_2"));
}

var configuration = new Configuration();

var conductorWorkflow = GetConductorWorkflow();
var workflowExecutor = new WorkflowExecutor(configuration);
workflowExecutor.RegisterWorkflow(
    workflow: conductorWorkflow
    overwrite: true
);
var workflowId = workflowExecutor.StartWorkflow(conductorWorkflow);
```

### More Examples
You can find more examples at the following GitHub repository:

https://github.com/conductor-sdk/conductor-examples
