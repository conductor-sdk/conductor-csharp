using Conductor.Models;
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

        public ForkJoinTask WithJoinOn(params WorkflowTask[] tasks)
        {
            if (JoinOn == null)
            {
                JoinOn = new List<string>();
            }
            foreach (WorkflowTask task in tasks)
            {
                JoinOn.Add(task.TaskReferenceName);
            }
            return this;
        }
    }
}
