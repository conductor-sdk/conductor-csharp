using Conductor.Client.Models;
using System.Collections.Generic;

namespace Conductor.Definition.TaskType
{
    public class ForkJoinTask : Task
    {
        public ForkJoinTask(string taskReferenceName, params WorkflowTask[][] forkTasks) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.FORKJOIN)
        {
            ForkTasks = new List<List<WorkflowTask>>();
            foreach (WorkflowTask[] forkTask in forkTasks)
            {
                ForkTasks.Add(new List<WorkflowTask>(forkTask));
            }
        }
    }
}
