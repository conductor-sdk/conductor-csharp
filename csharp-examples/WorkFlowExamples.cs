using Conductor.Client;
using Conductor.Definition.TaskType;
using Conductor.Definition;
using Conductor.Executor;
using Conductor.Api;
using Conductor.Client.Authentication;

namespace csharp_examples
{
    public class WorkFlowExamples
    {

        private const string KEY_ID = "<REPLACE_WITH_KEY_ID>";
        private const string KEY_SECRET = "<REPLACE_WITH_KEY_SECRET>";
        private const string OWNER_EMAIL = "<REPLACE_WITH_OWNER_EMAIL>";

        private const string WORKFLOW_NAME = "<REPLACE_WITH_WORKFLOW_NAME>";
        private const string WORKFLOW_DESCRIPTION = "<REPLACE_WITH_WORKFLOW_DESCRIPTION>";
        private const string TASK_NAME = "<REPLACE_WITH_TASK_NAME >";
        private const string TASK_REFERENCE = "<REPLACE_WITH_TASK_REFERENCE_NAME>";

        private const string VARIABLE_OLD_VALUE = "SOME_OLD_VALUE";
        private const string VARIABLE_NAME_1 = "<REPLACE_WITH_VARIABLE_NAME_1>";
        private const string VARIABLE_NAME_2 = "<REPLACE_WITH_VARIABLE_NAME_2>";


        public void RegisterWorkFlow()
        {
            Configuration configuration = new Configuration()
            {
                AuthenticationSettings = new OrkesAuthenticationSettings(KEY_ID, KEY_SECRET)
            };

            WorkflowExecutor executor = new WorkflowExecutor(configuration);
            executor.RegisterWorkflow(GetConductorWorkflow(), true);
        }

        private ConductorWorkflow GetConductorWorkflow()
        {
            var conductorWorkFlow = new ConductorWorkflow()
                .WithName(WORKFLOW_NAME).WithDescription(WORKFLOW_DESCRIPTION)
                .WithTask(new SimpleTask(TASK_NAME, TASK_REFERENCE))
            .WithOwner(OWNER_EMAIL);

            var workflowVariableTobeAdded = new Dictionary<string, object>
            {
                { VARIABLE_NAME_1, VARIABLE_OLD_VALUE},
                { VARIABLE_NAME_2, VARIABLE_OLD_VALUE }
            };

            conductorWorkFlow.Variables = workflowVariableTobeAdded;
            return conductorWorkFlow;
        }

        

    }
}
