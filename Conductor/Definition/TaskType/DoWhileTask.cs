using Conductor.Models;
using System.Collections.Generic;

namespace Conductor.Definition.TaskType
{
    public class DoWhileTask : Task
    {
        public DoWhileTask(string taskReferenceName, string loopCondition, params WorkflowTask[] loopOver) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.DOWHILE)
        {
            LoopCondition = loopCondition;
            if (LoopOver == null)
            {
                LoopOver = new List<WorkflowTask>();
            }
            foreach (WorkflowTask task in loopOver)
            {
                LoopOver.Add(task);
            }
        }
    }

    public class LoopTask : DoWhileTask
    {
        public LoopTask(string taskReferenceName, int iterations, params WorkflowTask[] loopOver) :
            base(
                taskReferenceName: taskReferenceName,
                loopCondition: GetForLoopCondition(taskReferenceName, iterations),
                loopOver: loopOver
            )
        { }

        private static string GetForLoopCondition(string taskReferenceName, int iterations)
        {
            return "if ( $." + taskReferenceName + "['iteration'] < " + iterations.ToString() + " ) { true; } else { false; }";
        }
    }
}
