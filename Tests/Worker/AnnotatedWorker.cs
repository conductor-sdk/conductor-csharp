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
