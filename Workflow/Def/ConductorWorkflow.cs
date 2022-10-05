using System.Collections.Generic;

namespace Conductor.Client.Workflow.Def
{
    internal class ConductorWorkflow
    {
        private string name { get; set; }
        private string description { get; set; }
        private int version { get; set; }
        private string failureWorkflow { get; set; }
        private string ownerEmail { get; set; }
        private Models.TaskDef.TimeoutPolicyEnum timeoutPolicy { get; set; }
        private Dictionary<string, object> workflowOutput { get; set; }
        private long timeoutSeconds { get; set; }
        private bool restartable { get; set; }
        private Dictionary<string, object> variables { get; set; }

        private List<Task.Task> tasks { get; set; }
    }
}