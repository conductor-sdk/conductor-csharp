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
