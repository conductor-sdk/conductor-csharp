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
using Conductor.Definition.TaskType.LlmTasks;
using System.Collections.Generic;

namespace Conductor.Examples.Orkes.Workers
{
    public class ChatWorkers
    {
        public const string USERROLE = "user";
        public const string ASSISTANTROLE = "assistant";

        [WorkerTask(taskType: "prep", 5, "taskDomain", 2000, "workerId")]
        public static List<ChatMessage> CollectHistory(string userInput, string seedQuestion, string assistantResponse, List<ChatMessage> history)
        {
            var allHistory = new List<ChatMessage>();

            if (history != null)
            {
                allHistory.AddRange(history);
            }

            if (assistantResponse != null)
            {
                allHistory.Add(new ChatMessage(message: assistantResponse, role: ASSISTANTROLE));
            }

            if (userInput != null)
            {
                allHistory.Add(new ChatMessage(message: userInput, role: USERROLE));
            }
            else
            {
                allHistory.Add(new ChatMessage(message: seedQuestion, role: USERROLE));
            }

            return allHistory;
        }
    }
}
