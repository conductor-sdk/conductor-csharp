using System.Collections.Generic;

namespace Conductor.Definition.TaskType
{
    public class DynamicForkInput
    {
        public List<Task> Tasks { get; set; }

        public Dictionary<string, object> Inputs { get; set; }

        public DynamicForkInput(List<Task> tasks, Dictionary<string, object> inputs)
        {
            Tasks = tasks;
            Inputs = inputs;
        }
    }
}