# Authoring Workflows with the C# SDK

## A simple two-step workflow

```csharp
GetSimpleTask(string taskReferenceName)
{
    return new SimpleTask(taskReferenceName, taskReferenceName);
}

ConductorWorkflow GetConductorWorkflow()
{
    return new ConductorWorkflow()
        .WithName("my_first_workflow")
        .WithVersion(1)
        .WithOwner("developers@orkes.io")
            .WithTask(new SimpleTask("simple_task_2", "simple_task_1"))
            .WithTask(new SimpleTask("simple_task_1", "simple_task_2"));

WorkflowExecutor GetWorkflowExecutor()
{
    return new WorkflowExecutor(
        metadataClient: GetClient<MetadataResourceApi>(),
        workflowClient: GetClient<WorkflowResourceApi>()
    );
}

ConductorWorkflow conductorWorkflow = GetConductorWorkflow();
WorkflowExecutor workflowExecutor = GetWorkflowExecutor();
workflowExecutor.RegisterWorkflow(
    workflow: conductorWorkflow
    overwrite: true
);
String workflowId = workflowExecutor.StartWorkflow(conductorWorkflow);
```

### Workflow Management APIs
See [Docs](/docs/readme/executor.md) for APIs to start, pause, resume, terminate, search and get workflow execution status.

### More Examples
You can find more examples at the following GitHub repository:

https://github.com/conductor-sdk/conductor-examples
