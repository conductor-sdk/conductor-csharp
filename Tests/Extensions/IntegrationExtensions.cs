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
using Conductor.Client.Models;
using conductor_csharp.test.Helper;
using Newtonsoft.Json;
using System;

namespace conductor_csharp.test.Extensions
{
    /// <summary>
    /// Provides extension methods for working with integration-related functionalities.
    /// </summary>
    public static class IntegrationExtensions
    {
        public static void CreateIntegration(this IntegrationResourceApi integrationResourceApi, bool isPromptTemplate = false)
        {
            try
            {
                var jsonObject = LoadIntegrationData();
                IntegrationUpdate integrationUpdate = JsonConvert.DeserializeObject<IntegrationUpdate>(jsonObject.integrationUpdate.ToString());
                IntegrationApiUpdate integrationApiUpdate = JsonConvert.DeserializeObject<IntegrationApiUpdate>(jsonObject.integrationApiUpdate.ToString());
                string name = isPromptTemplate ? TestConstants.IntegrationPromptName : TestConstants.IntegrationName;
                string modelName = isPromptTemplate ? TestConstants.ModelPromptName : TestConstants.ModelName;

                integrationResourceApi.SaveIntegrationProvider(integrationUpdate, name);
                integrationResourceApi.SaveIntegrationApi(integrationApiUpdate, name, modelName);
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(TestConstants.CreateIntegartionErrorMessage, ex.Message);
                throw new Exception(errorMessage, ex);
            }
        }

        public static void DeleteIntegration(this IntegrationResourceApi integrationResourceApi, bool isPromptTemplate = false)
        {
            try
            {
                string name = isPromptTemplate ? TestConstants.IntegrationPromptName : TestConstants.IntegrationName;
                string modelName = isPromptTemplate ? TestConstants.ModelPromptName : TestConstants.ModelName;
                integrationResourceApi.DeleteIntegrationApi(name, modelName);
                integrationResourceApi.DeleteIntegrationProvider(name);
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(TestConstants.DeleteIntegartionErrorMessage, ex.Message);
                throw new Exception(errorMessage, ex);
            }
        }

        public static dynamic LoadIntegrationData()
        {
            string jsonFilePath = "TestData/integration_data.json";
            return JsonHelper.DeserializeJson<dynamic>(jsonFilePath);
        }

        public static string GetModelName(string integrationPromptName, string modelPromptName)
        {
            return string.Format("{0}:{1}", integrationPromptName, modelPromptName);
        }
    }
}
