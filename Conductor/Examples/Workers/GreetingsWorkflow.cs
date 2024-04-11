using Conductor.Client.Worker;
using Conductor.Definition;
using Conductor.Definition.TaskType;

namespace Conductor.Examples
{
    public class GreetingsWorkflow
    {
        private const string WorkflowName = "Test_Workflow_Greeting";
        private const string WorkflowDescription = "test description";

        [WorkerTask("greetings_task", 5, "taskDomain", 420, "workerId")]
        public string Greet(string name)
        {
            return $"Hello {name}";
        }

        public ConductorWorkflow CreateGreetingsWorkflow()
        {
            var wf = new ConductorWorkflow()
                .WithName(WorkflowName)
                .WithDescription(WorkflowDescription)
                .WithVersion(1)
                //Here call Greet() instead of creating SimpleTask manually.
                .WithTask(new SimpleTask("greetings_task_test", "greet_ref_test"));
            return wf;
        }
    }
}