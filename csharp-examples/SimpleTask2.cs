using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using Conductor.Client.Extensions;

namespace csharp.examples
{
    public class SimpleTask2 : IWorkflowTask
    {
        public string TaskType { get; }
        public WorkflowTaskExecutorConfiguration WorkerSettings { get; }

        public SimpleTask2(string taskType = "SimpleTask_2")
        {
            TaskType = taskType;
            WorkerSettings = new WorkflowTaskExecutorConfiguration();
        }

        public async Task<TaskResult> ExecuteAsync(Conductor.Client.Models.Task task, CancellationToken token)
        {
            if (token != CancellationToken.None && token.IsCancellationRequested)
                return task.Failed("Token request Cancel");

            return await System.Threading.Tasks.Task.Run(() => task.Completed());
        }

        public TaskResult Execute(Conductor.Client.Models.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
