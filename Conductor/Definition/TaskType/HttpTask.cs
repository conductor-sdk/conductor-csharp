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
using Conductor.Client.Models;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Conductor.Definition.TaskType
{
    public class HttpTask : Task
    {
        private static string HTTP_PARAMETER = "http_request";

        public HttpTask(string taskReferenceName, HttpTaskSettings input = default(HttpTaskSettings)) : base(taskReferenceName, WorkflowTask.WorkflowTaskTypeEnum.HTTP)
        {
            WithInput(HTTP_PARAMETER, input.ToDictionary());
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
