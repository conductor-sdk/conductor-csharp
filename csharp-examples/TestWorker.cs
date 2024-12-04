/*
 * Copyright 2024 Conductor Authors.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */
using Conductor.Client.Extensions;
using Conductor.Client.Interfaces;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using Task = Conductor.Client.Models.Task;

namespace csharp.examples;

public class TestWorker : IWorkflowTask
{

    private readonly Random rnd = new();

    private readonly string _taskType;

    public TestWorker(string taskType)
    {
        _taskType = taskType;
    }

    public string TaskType => _taskType;
    public WorkflowTaskExecutorConfiguration WorkerSettings { get; } = new WorkflowTaskExecutorConfiguration()
    {
        BatchSize = 20
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

            //Simulate work - once in a while
            var sleepTime = rnd.Next(0, 2);
            Thread.Sleep(TimeSpan.FromSeconds(sleepTime));

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