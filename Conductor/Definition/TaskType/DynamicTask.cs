namespace Conductor.Definition.TaskType
{
    public class DynamicTask : Task
    {
        /// <summary>
        /// Gets or Sets DynamicTaskParam
        /// </summary>
        public string DynamicTaskParam { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTask" /> class.
        /// </summary>
        /// <param name="dynamicTask"></param>
        /// <param name="taskRefName"></param>
        /// <param name="dynamicTaskParam"></param>
        public DynamicTask(string dynamicTask, string taskRefName, string dynamicTaskParam = "taskToExecute")
        : base(taskRefName, WorkflowTaskTypeEnum.DYNAMIC)
        {
            WithInput(dynamicTaskParam, dynamicTask);
            DynamicTaskParam = dynamicTaskParam;
        }
    }
}
