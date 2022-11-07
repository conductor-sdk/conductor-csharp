using Conductor.Models;
using System;

namespace Conductor.Definition.TaskType
{
    public class WaitTask : Task
    {
        private static string DURATION_PARAMETER = "duration";
        private static string UNTIL_PARAMETER = "until";

        public WaitTask(string taskReferenceName, TimeSpan duration) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.WAIT)
        {
            WithInput(DURATION_PARAMETER, duration.Seconds.ToString() + "s");
        }

        public WaitTask(string taskReferenceName, DateTime until) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.WAIT)
        {
            WithInput(UNTIL_PARAMETER, until.ToString("yyyy-MM-dd HH:mm z"));
        }
    }
}
