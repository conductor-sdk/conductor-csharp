using Conductor.Models;

namespace Conductor.Definition.TaskType
{
    public class SimpleTask : Task
    {
        public SimpleTask(string taskName, string taskReferenceName) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.SIMPLE)
        {
            WithName(taskName);
        }
    }
}