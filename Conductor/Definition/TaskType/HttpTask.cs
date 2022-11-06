using Conductor.Models;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Conductor.Definition.TaskType
{
    public class HttpTask : Task
    {

        public HttpTask(string taskReferenceName) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.HTTP) { }

        public HttpTask WithSettings(HttpTaskSettings input)
        {
            Input("http_request", input.ToDictionary());
            return this;
        }
    }

    public class HttpTaskSettings
    {
        public string uri { get; set; }
        public string method { get; set; }
        public string accept { get; set; }
        public string contentType { get; set; }
        public Dictionary<string, object> headers { get; set; }
        public object body { get; set; }
        public string vipAddress { get; set; }
        public bool asyncComplete { get; set; }
        public bool oauthConsumerKey { get; set; }
        public bool oauthConsumerSecret { get; set; }
        public int connectionTimeOut { get; set; }
        public int readTimeOut { get; set; }

        public HttpTaskSettings()
        {
            method = HttpMethod.Get.ToString();
            accept = "application/json";
            contentType = "application/json";
            headers = new Dictionary<string, object>();
        }

        public Dictionary<string, object> ToDictionary()
        {
            string serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(serialized);
        }
    }
}
