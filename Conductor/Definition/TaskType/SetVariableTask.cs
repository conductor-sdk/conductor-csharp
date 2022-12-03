using Conductor.Client.Models;

namespace Conductor.Definition.TaskType
{
    public class SetVariableTask : Task
    {
        public SetVariableTask(string taskReferenceName) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.SETVARIABLE) { }
    }
}
