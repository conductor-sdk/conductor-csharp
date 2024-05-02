using Conductor.Client.Worker;
using conductor_csharp.test.Helper;

namespace Tests.Worker
{
    [WorkerTask]
    public class AnnotatedWorker
    {
        [WorkerTask(taskType: TestConstants.QuoteTaskName, workerId: "workerId", batchSize: 20, pollIntervalMs: 520)]
        [OutputParam("outputValue")]
        public string GetQuote()
        {
            return TestConstants.Quote;
        }

        [WorkerTask(taskType: TestConstants.InputTaskName, workerId: "workerId", batchSize: 20, pollIntervalMs: 520)]
        [OutputParam("outputValue")]
        public string GetInputValue([InputParam("userId")] string userId, int otp)
        {
            return $"userId: {userId}@example.com and otp:{otp}";
        }

        [WorkerTask(taskType: TestConstants.TestAddTask, workerId: "workerId", batchSize: 20, pollIntervalMs: 520)]
        [OutputParam("outputValue")]
        public string AddValue([InputParam("numberOne")] int numberOne, [InputParam("numberTwo")] int numberTwo)
        {
            return $"final value : {numberOne + numberTwo}";
        }
    }
}
