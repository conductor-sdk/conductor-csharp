using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using Task = Conductor.Client.Models.Task;

namespace csharp.examples;

public class TestWorker(string taskType) : IWorkflowTask
{
    private readonly Random rnd = new();

    public string TaskType { get; } = taskType;
    public WorkflowTaskExecutorConfiguration WorkerSettings { get; } = new WorkflowTaskExecutorConfiguration()
    {
        BatchSize = 10
    };

    public async Task<TaskResult> Execute(Task task, CancellationToken token)
    {
        if (token != CancellationToken.None && token.IsCancellationRequested)
            return task.Failed("Token request Cancel");


        return await System.Threading.Tasks.Task.Run(() =>
        {
            var num = rnd.Next(5, 20);
            var result = task.Completed();
            result.OutputData = new Dictionary<string, object>();
            for (var i = 0; i < num; i++)
            {
                result.OutputData["Key_" + i] = CreateString(12);
                result.OutputData["Num_" + i] = rnd.NextDouble();
            }

            return result;
        });
    }

    public TaskResult Execute(Task task)
    {
        throw new NotImplementedException();
    }

    internal string CreateString(int stringLength)
    {
        const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
        var chars = new char[stringLength];

        for (var i = 0; i < stringLength; i++) chars[i] = allowedChars[rnd.Next(0, allowedChars.Length)];

        return new string(chars);
    }
}