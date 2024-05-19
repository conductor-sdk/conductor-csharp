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
using Conductor.Api;
using Conductor.Client.Authentication;
using Conductor.Client;

namespace csharp_examples
{
    public class HumanTaskExamples
    {
        public void GetUserFormTemplatesBasedOnName(string name)
        {
            var orkesApiClient = new OrkesApiClient(new Configuration(),
                new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));
            var workflowClient = orkesApiClient.GetClient<HumanTaskResourceApi>();
            var responseTemplate = workflowClient.GetAllTemplates(name, null);
            if (responseTemplate != null && responseTemplate.Count > 0)
            {
                responseTemplate.ForEach(x =>
                {
                    Console.WriteLine(x.Name);
                });
            }
        }
    }
}
