using Conductor.Models;

namespace Conductor.Definition.TaskType
{
    public class EventTask : Task
    {
        private static string SINK_PARAMETER = "sink";

        public string Sink { get; set; }

        public EventTask(string taskReferenceName, string eventSink) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.EVENT)
        {
            Sink = eventSink;
        }

        public override WorkflowTask ToWorkflowTask()
        {
            WorkflowTask workflowTask = base.ToWorkflowTask();
            workflowTask.Sink = Sink;
            return workflowTask;
        }
    }
}
