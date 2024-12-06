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
using conductor.csharp.Client.Extensions;
using Conductor.Api;
using Conductor.Client.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Conductor.Examples
{
    public class TaskConfigure
    {
        private readonly MetadataResourceApi _metaDataClient;
        private readonly ILogger logger;
        private const string url = "https://sdkdev.orkesconductor.io/taskDef/";
        public TaskConfigure()
        {
            //metaDataClient = ApiExtensions.GetClient<MetadataResourceApi>();
            logger = ApplicationLogging.CreateLogger<TaskConfigure>();

            // dev local testing
            //Configuration configuration = new Configuration();
            //var _orkesApiClient = new OrkesApiClient(configuration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            //_metaDataClient = _orkesApiClient.GetClient<MetadataResourceApi>();
        }
        TaskDef taskDef = new TaskDef()
        {
            Name = "task_with_retries",
            Description = "task_with_retries description",
            RetryCount = 3,
            RetryLogic = TaskDef.RetryLogicEnum.LINEARBACKOFF,
            RetryDelaySeconds = 1,
            ConcurrentExecLimit = 3,
            PollTimeoutSeconds = 60,
            TimeoutSeconds = 120,
            ResponseTimeoutSeconds = 60,
            RateLimitPerFrequency = 100,
            RateLimitFrequencyInSeconds = 10
        };
        public void RegisterTaskDef()
        {
            _metaDataClient.RegisterTaskDef(new List<TaskDef>() { taskDef });
            logger.LogInformation($"Registered the task -- see the details in {url}/{taskDef.Name}");

        }
    }
}
