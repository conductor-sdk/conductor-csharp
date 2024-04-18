using conductor.csharp.Client.Extensions;
using Conductor.Api;
using Conductor.Client;
using Conductor.Client.Ai;
using Conductor.Client.Extensions;
using Conductor.Client.Models;
using Conductor.Client.Worker;
using Conductor.Definition;
using Conductor.Definition.TaskType;
using Conductor.Examples.Orkes;
using Conductor.Examples.Workers;
using Conductor.Executor;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;

namespace Conductor.Examples
{
    public class WaitForWebhook
    {
        private readonly Client.Configuration _configuration;
        private readonly Orchestrator _orchestrator;
        private readonly OpenAIConfig _openAIConfig;
        private readonly WorkflowExecutor _workflowExecutor;
        private readonly WorkflowResourceApi _workflowClient;
        private readonly MetadataResourceApi _metadataClient;
        private readonly ILogger _logger;

        //Const
        private const string WORKFLOWNAME = "dynamic_workflow";
        private const string WORKFLOWDESC = "test_dynamic_workflow";

        public WaitForWebhook()
        {
            _configuration = new Client.Configuration();
            _workflowExecutor = new WorkflowExecutor(_configuration);
            _workflowClient = ApiExtensions.GetClient<WorkflowResourceApi>();
            _metadataClient = ApiExtensions.GetClient<MetadataResourceApi>();
            _logger = ApplicationLogging.CreateLogger<OpenAIChatGpt>();

            //For local testing
            //var _orkesApiClient = new OrkesApiClient(_configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_workflowClient = _orkesApiClient.GetClient<WorkflowResourceApi>();
            //_metaDataClient = _orkesApiClient.GetClient<MetadataResourceApi>();
        }

        [WorkerTask(taskType: "GetEmail", 5, "taskDomain", 520, "workerId")]
        public string GetUserEmail(string userId)
        {
            return $"{userId}@example.com";
        }

        [WorkerTask(taskType: "SendEmail", 5, "taskDomain", 520, "workerId")]
        public string SendEmail(string email, string subject, string body)
        {
            return $"sending email to {email} with subject {subject} and body {body}";
        }

        public void WaitForWebhookTest()
        {
            ConductorWorkflow workflow = new ConductorWorkflow()
                .WithName(WORKFLOWNAME)
                .WithDescription(WORKFLOWDESC)
                .WithVersion(1);

            workflow.WithInputParameter("userId");

            //Update this line to use GetUserEmail() once the annotation is in place
            var getEmailTask = new SimpleTask("GetEmail", "GetEmail").WithInput("userId", workflow.Input("userId"));
            getEmailTask.Description = "Test Get email";

            workflow.WithTask(getEmailTask);

            ////Update this line to use SendEmail() once the annotation is in place
            var SendEmailTask = new SimpleTask("SendEmail", "Send_Email_refTask")
                .WithInput("email", getEmailTask.Output("userId"))
                .WithInput("subject", "Hello from Orkes")
                .WithInput("body", "Test Email");

            workflow.WithTask(SendEmailTask);

            var WaitForWebhookTask = new WaitForWebHookTask("wait_ref", new Dictionary<string, object> { { "type", "customer" }, { "id", workflow.Input("userId") } });
            workflow.WithTask(WaitForWebhookTask);

            _workflowExecutor.RegisterWorkflow(workflow, true);

            var testInput = new Dictionary<string, object>
            {
                { "userId", "Test" }
            };

            StartWorkflowRequest startWorkflow = new StartWorkflowRequest()
            {
                Name = workflow.Name,
                Input = testInput,
                Version = workflow.Version,
                WorkflowDef = workflow,
                CreatedBy = Constants.OWNER_EMAIL
            };

            var workflowRun = _workflowClient.ExecuteWorkflow(startWorkflow, "1234", startWorkflow.Name, 1);
            var waitHandle = new ManualResetEvent(false);
            var backgroundTask = System.Threading.Tasks.Task.Run(async () => await Utils.WorkerUtil.StartBackGroundTask(waitHandle, new DynamicWorker("GetEmail")));
            waitHandle.WaitOne();
            _logger.LogInformation($"\nworkflow execution {workflowRun.WorkflowId}\n");
        }
    }
}