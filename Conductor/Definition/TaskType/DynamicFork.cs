using Conductor.Client.Models;
using Conductor.Definition.TaskType;
using Task = Conductor.Definition.TaskType.Task;

namespace Definition.TaskType
{
    public class DynamicFork : Task
    {
        public string ForkTasksParameter { get; set; }

        public string ForkTasksInputsParameter { get; set; }

        public JoinTask Join { get; set; }

        public const string FORK_TASK_PARAM = "forkedTasks";
        public const string FORK_TASK_INPUT_PARAM = "forkedTasksInputs";

        public DynamicFork(string taskReferenceName, string forkTasksParameter, string forkTasksInputsParameter) : base(taskReferenceName, WorkflowTaskTypeEnum.FORKJOINDYNAMIC)
        {
            this.Join = new JoinTask(taskReferenceName + "_join");
            this.ForkTasksParameter = forkTasksParameter;
            this.ForkTasksInputsParameter = forkTasksInputsParameter;
            base.InputParameters.Add(FORK_TASK_PARAM, forkTasksParameter);
            base.InputParameters.Add(FORK_TASK_INPUT_PARAM, forkTasksInputsParameter);
        }

        public override void UpdateWorkflowTask(WorkflowTask task)
        {
            task.SetDynamicForkJoinTasksParam("forkedTasks");
            task.SetDynamicForkTasksInputParamName("forkedTasksInputs");
        }
    }
}