using Conductor.Client;
using Conductor.Definition.TaskType;
using Conductor.Definition;
using Conductor.Executor;
using Conductor.Api;
using Conductor.Client.Authentication;
using Newtonsoft.Json;

namespace csharp_examples
{
    public class WorkFlowExamples
    {

        private const string WORKFLOW_ID = "<REPLACE_WITH_WORKFLOW_ID>";
        private const string WORKFLOW_NAME = "<REPLACE_WITH_WORKFLOW_NAME>";
        private const string WORKFLOW_DESCRIPTION = "<REPLACE_WITH_WORKFLOW_DESCRIPTION>";
        private const string TASK_NAME = "<REPLACE_WITH_TASK_NAME >";
        private const string TASK_REFERENCE = "<REPLACE_WITH_TASK_REFERENCE_NAME>";

        private const string VARIABLE_OLD_VALUE = "SOME_OLD_VALUE";
        private const string VARIABLE_NAME_1 = "<REPLACE_WITH_VARIABLE_NAME_1>";
        private const string VARIABLE_NEW_VALUE_1 = "<REPLACE_WITH_OWNER_VALUE_1>";
        private const string VARIABLE_NAME_2 = "<REPLACE_WITH_VARIABLE_NAME_2>";
        private const string VARIABLE_NEW_VALUE_2 = "<REPLACE_WITH_OWNER_VALUE_2>";

        public void RegisterWorkFlow()
        {
            // Method-1 for using custom serialization settings - START

            // Step 1:- Prepare JsonSerializer Settings with certain properties
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            // Step 2:- Use overloaded constructor of Configuration and pass the JsonSerializer Settings 
            // Restclient internally use the settings to serialize on request/response while making a call to serialize/deserialize
            Configuration configuration = new Configuration(jsonSerializerSettings, Constants.REST_CLIENT_REQUEST_TIME_OUT)
            {
                AuthenticationSettings = new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET)
            };

            WorkflowExecutor executor = new WorkflowExecutor(configuration);
            executor.RegisterWorkflow(GetConductorWorkflow(), true);
            // Method-1 for using custom serialization settings - END


            // Method-2 for using custom serialization settings - START
            /*
                Configuration configuration = new Configuration();
                configuration.ApiClient.serializerSettings = new JsonSerializerSettings()
                                {
                                    Formatting = Formatting.Indented,
                                    NullValueHandling = NullValueHandling.Ignore
                                };
                WorkflowExecutor executor = new WorkflowExecutor(configuration);
                executor.RegisterWorkflow(GetConductorWorkflow(), true);
             */
            // Method-2 for using custom serialization settings - END
        }

        private ConductorWorkflow GetConductorWorkflow()
        {
            var conductorWorkFlow = new ConductorWorkflow()
                .WithName(WORKFLOW_NAME).WithDescription(WORKFLOW_DESCRIPTION)
                .WithTask(new SimpleTask(TASK_NAME, TASK_REFERENCE))
            .WithOwner(Constants.OWNER_EMAIL);

            var workflowVariableTobeAdded = new Dictionary<string, object>
            {
                { VARIABLE_NAME_1, VARIABLE_OLD_VALUE},
                { VARIABLE_NAME_2, VARIABLE_OLD_VALUE }
            };

            conductorWorkFlow.Variables = workflowVariableTobeAdded;
            return conductorWorkFlow;
        }

        /// <summary>
        /// To test Update variables with workflowId
        /// </summary>
        public void TestUpdateWorkflowVariablesWithWorkFlowId()
        {
            var orkesApiClient = new OrkesApiClient(new Configuration(),
                new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            var workflowClient = orkesApiClient.GetClient<WorkflowResourceApi>();
            var workFlowVariables = new Dictionary<string, object>
            {
                { VARIABLE_NAME_1, VARIABLE_NEW_VALUE_1 },
                { VARIABLE_NAME_2, VARIABLE_NEW_VALUE_2 }
            };

            workflowClient.UpdateWorkflowVariables(WORKFLOW_ID, workFlowVariables);
        }

        /// <summary>
        /// To Terminate Workflow Execution using WorkflowId
        /// </summary>
        /// <param name="WorkflowId"></param>
        public void TestTerminateWorkflowExecution(String WorkflowId)
        {
            var orkesApiClient = new OrkesApiClient(new Configuration(),
            new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            var workflowClient = orkesApiClient.GetClient<WorkflowResourceApi>();
            workflowClient.Terminate(WORKFLOW_ID, null, null);
        }

        /// <summary>
        /// To remove Workflow from the system using workflowId
        /// </summary>
        /// <param name="WorkflowId"></param>
        public void TestRemoveWorkflow(String WorkflowId)
        {
            var orkesApiClient = new OrkesApiClient(new Configuration(),
            new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            var workflowClient = orkesApiClient.GetClient<WorkflowResourceApi>();
            workflowClient.Delete(WorkflowId, null);
        }

        /// <summary>
        /// To Retry the last failed Task using WorkflowId
        /// </summary>
        /// <param name="WorkflowId"></param>
        public void TestRetryLastFailedTask(String WorkflowId)
        {
            var orkesApiClient = new OrkesApiClient(new Configuration(),
            new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            var workflowClient = orkesApiClient.GetClient<WorkflowResourceApi>();
            workflowClient.Retry(WorkflowId, null);
        }

        /// <summary>
        /// To Pause the Running Workflow using WorkflowId
        /// </summary>
        /// <param name="WorkflowId"></param>
        public void TestPauseworkflow(String WorkflowId)
        {
            var orkesApiClient = new OrkesApiClient(new Configuration(),
            new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            var workflowClient = orkesApiClient.GetClient<WorkflowResourceApi>();
            workflowClient.PauseWorkflow(WorkflowId);
        }

        /// <summary>
        /// To Get Execution Status of the Workflow using WorkflowId
        /// </summary>
        /// <param name="WorkflowId"></param>
        public void TestGetWorkflowByWorkflowId(String WorkflowId)
        {
            var orkesApiClient = new OrkesApiClient(new Configuration(),
            new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            var workflowClient = orkesApiClient.GetClient<WorkflowResourceApi>();
            workflowClient.GetExecutionStatus(WorkflowId, null);
        }

        /// <summary>
        /// To Resume the Paused Workflow with WorkflowId with our own custom values for timeout.
        /// </summary>
        /// <param name="WorkflowId"></param>
        public void TestResumeWorkflow(String WorkflowId)
        {
            Configuration configuration = new Configuration(timeOut: 20000);
            configuration.BasePath = "https://play.orkes.io/api";

            var orkesApiClient = new OrkesApiClient(new Configuration(timeOut: 20000),
            new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            var workflowClient = orkesApiClient.GetClient<WorkflowResourceApi>();
            workflowClient.ResumeWorkflow(WorkflowId);
        }
    }
}
