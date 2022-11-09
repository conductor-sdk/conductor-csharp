using Conductor.Models;
using System.Collections.Generic;

namespace Conductor.Definition.TaskType
{
    public class JoinTask : Task
    {
        public JoinTask(string taskReferenceName, params WorkflowTask[] joinOn) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.JOIN)
        {
            JoinOn = new List<string>();
            foreach (WorkflowTask forkTask in joinOn)
            {
                JoinOn.Add(forkTask.TaskReferenceName);
            }
        }
    }
}