using Conductor.Client.Models;

namespace Conductor.Definition.TaskType
{
    public class DynamicForkTask : Task
    {
        public DynamicForkTask(string taskReferenceName, string taskNameParameter) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.DYNAMIC)
        {
            DynamicTaskNameParam = taskNameParameter;
        }
    }
}
