using Conductor.Client.Models;

namespace Conductor.Definition.TaskType
{
    public class EventTask : Task
    {
        public EventTask(string taskReferenceName, string eventSink) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.EVENT)
        {
            Sink = eventSink;
        }
    }
}
