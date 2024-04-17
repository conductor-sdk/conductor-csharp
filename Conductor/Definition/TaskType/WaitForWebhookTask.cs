using System.Collections.Generic;

namespace Conductor.Definition.TaskType
{
    public class WaitForWebHookTask : Task
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WaitForWebHookTask" /> class.
        /// </summary>
        /// <param name="taskReferenceName"></param>
        /// <param name="matches"></param>
        public WaitForWebHookTask(string taskReferenceName, Dictionary<string, object> matches) : base(taskReferenceName, WorkflowTaskTypeEnum.WAITFORWEBHOOK)
        {
            InputParameters = matches;
        }
    }
}