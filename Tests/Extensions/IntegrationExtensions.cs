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
        public static void CreateIntegration(IntegrationResourceApi integrationResourceApi, bool isPromptTemplate = false)
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

        public static void DeleteIntegration(IntegrationResourceApi integrationResourceApi, bool isPromptTemplate = false)
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
