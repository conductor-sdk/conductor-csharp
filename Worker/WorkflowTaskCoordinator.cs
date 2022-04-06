using Conductor.Client.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Conductor.Client.Worker
{
    internal class WorkflowTaskCoordinator : IWorkflowTaskCoordinator
    {
        private int concurrentWorkers;
        private IServiceProvider serviceProvider;
        private ILogger<WorkflowTaskCoordinator> logger;
        private HashSet<Type> workerDefinitions = new HashSet<Type>();
        private ConductorClientSettings conductorClientSetting;

        public WorkflowTaskCoordinator(IServiceProvider serviceProvider,
            ILogger<WorkflowTaskCoordinator> logger,
            IOptions<ConductorClientSettings> conductorClientSettings)
         {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
            concurrentWorkers = conductorClientSettings.Value.ConcurrentWorkers;
            conductorClientSetting = conductorClientSettings.Value;
        }

        public async Task Start()
        {
            logger.LogInformation("Starting WorkflowCoordinator");
            if (this.conductorClientSetting.AuthenticationClient != null 
                && !string.IsNullOrEmpty(this.conductorClientSetting.AuthenticationClient.keyId)
                && !string.IsNullOrEmpty(this.conductorClientSetting.AuthenticationClient.keySecret))
            {
                this.conductorClientSetting.Token = PostForToken().Result;
            }
            var pollers = new List<Task>();
            for (var i = 0; i < concurrentWorkers; i++)
            {
                var executor = serviceProvider.GetService(typeof(IWorkflowTaskExecutor)) as IWorkflowTaskExecutor;
                pollers.Add(executor.StartPoller(workerDefinitions.ToList()));
            }

            await Task.WhenAll(pollers);
        }

        public void RegisterWorker<T>(T task) where T : IWorkflowTask
        {
            workerDefinitions.Add(task.GetType());
        }
        public async Task<string> PostForToken()
        {
            HttpClient httpClient = new HttpClient();
            var urlBuilder = new StringBuilder("https://play.orkes.io/api/token");

            using (var request = new HttpRequestMessage { Method = HttpMethod.Post, RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute) })
            {
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                request.Content = JsonContent.Create(new
                {
                    keyId = "45b5c4ad-a758-45b7-9f65-3721d9371b47",
                    keySecret = "MjsJCFHTrs5RRCj7W1soEYecLbaOUT5ZCOSq6sHxWXqsAvLY"
                });
                var response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;


                var result = (JObject)JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                return result["token"].Value<string>();

            }
        }
    }
}
