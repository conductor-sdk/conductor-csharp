namespace Conductor.Definition.TaskType.SimpleTask
{
    public class SimpleTask : Task
    {
        public SimpleTask(string taskName, string taskReferenceName) : base(taskReferenceName, Models.WorkflowTask.WorkflowTaskTypeEnum.SIMPLE.ToString())
        {
            Name(taskName);
        }
    }
}