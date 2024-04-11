using Conductor.Api;
using Conductor.Client.Authentication;
using Conductor.Client.Models;
using System;
using System.Collections.Generic;
using static Conductor.Client.Ai.Configuration;
using Config = Conductor.Client.Configuration;

namespace Conductor.Client.Ai
{
    /// <summary>
    /// Orchestrator
    /// </summary>
    public class Orchestrator
    {
        private readonly IntegrationResourceApi _integrationResourceApi;
        private readonly WorkflowResourceApi _workflowResourceApi;
        private readonly PromptResourceApi _promptResourceApi;
        private readonly string _promptTestWorkflowName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Orchestrator" /> class
        /// </summary>
        /// <param name="apiConfiguration"></param>
        /// <param name="promptTestWorkflowName"></param>
        public Orchestrator(Config apiConfiguration, string promptTestWorkflowName = "")
        {
            var orkesApiClients = new OrkesApiClient(apiConfiguration, new OrkesAuthenticationSettings(Constants.KEY_ID, Constants.KEY_SECRET));

            _integrationResourceApi = orkesApiClients.GetClient<IntegrationResourceApi>();
            _workflowResourceApi = orkesApiClients.GetClient<WorkflowResourceApi>();
            _promptResourceApi = orkesApiClients.GetClient<PromptResourceApi>();
            _promptTestWorkflowName = string.IsNullOrEmpty(promptTestWorkflowName) ? Constants.PROMPTTESTWORKFLOWDEFAULTNAME + Guid.NewGuid().ToString() : promptTestWorkflowName;
        }

        /// <summary>
        /// Method to add prompt template
        /// </summary>
        /// <param name="promptTemplate"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Orchestrator AddPromptTemplate(string promptTemplate, string description, string name, List<string> models = null)
        {
            try
            {
                _promptResourceApi.SaveMessageTemplate(promptTemplate, description, name, models);
                return this;
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(Constants.ADD_PROMPT_TEMPLATE_ERROR_MESSAGE, ex.Message);
                throw new Exception(errorMessage, ex);
            }
        }

        /// <summary>
        ///  Method to get prompt template
        /// </summary>
        /// <param name="templateName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public MessageTemplate GetPromptTemplate(string templateName)
        {
            try
            {
                return _promptResourceApi.GetMessageTemplate(templateName);
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(Constants.GET_PROMPT_TEMPLATE_ERROR_MESSAGE, ex.Message);
                throw new Exception(errorMessage, ex);
            }
        }

        /// <summary>
        ///  Method to associate prompt template with integration
        /// </summary>
        /// <param name="integrationProvider"></param>
        /// <param name="aiModels"></param>
        /// <param name="PromptName"></param>
        /// <exception cref="Exception"></exception>
        public void AssociatePromptTemplate(string integrationProvider, List<string> aiModels, string PromptName)
        {
            try
            {
                foreach (var aiModel in aiModels)
                    _integrationResourceApi.AssociatePromptWithIntegration(integrationProvider, aiModel, PromptName);
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(Constants.ASSOCIATE_PROMPT_TEMPLATE_ERROR_MESSAGE, ex.Message);
                throw new Exception(errorMessage, ex);
            }
        }

        /// <summary>
        ///  Method to test prompt template
        /// </summary>
        /// <param name="promptTemplateTestRequest"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string TestPromptTemplate(PromptTemplateTestRequest promptTemplateTestRequest)
        {
            try
            {
                return _promptResourceApi.TestMessageTemplate(promptTemplateTestRequest);
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(Constants.TEST_MESSAGE_TEMPLATE_ERROR_MESSAGE, ex.Message);
                throw new Exception(errorMessage, ex);
            }
        }

        /// <summary>
        ///  Method to add AI Integration using LLMProvider
        /// </summary>
        /// <param name="aiIntegrationName"></param>
        /// <param name="provider"></param>
        /// <param name="models"></param>
        /// <param name="description"></param>
        /// <param name="config"></param>
        /// <param name="overwrite"></param>
        /// <exception cref="Exception"></exception>
        public void AddAIIntegration(string aiIntegrationName, LLMProviderEnum provider, List<string> models, string description, IntegrationConfig config, bool overwrite = false)
        {
            IntegrationUpdate details = null;
            try
            {
                details = new IntegrationUpdate();
                details.Configuration = config.ToDictionary();
                details.Type = provider.ToString();
                details.Category = IntegrationUpdate.CategoryEnum.AIMODEL;
                details.Enabled = true;
                details.Description = description;
                var existingIntegration = _integrationResourceApi.GetIntegrationProvider(aiIntegrationName);
                if (existingIntegration == null || overwrite)
                    _integrationResourceApi.SaveIntegrationProvider(details, aiIntegrationName);
                SaveIntegrationApis(aiIntegrationName, models, description, overwrite);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404") && details != null)
                {
                    _integrationResourceApi.SaveIntegrationProvider(details, aiIntegrationName);
                    SaveIntegrationApis(aiIntegrationName, models, description, overwrite);
                }
                else
                {
                    string errorMessage = string.Format(Constants.ADD_AI_INTEGRATION_ERROR_MESSAGE, ex.Message);
                    throw new Exception(errorMessage, ex);
                }
            }
        }

        /// <summary>
        /// Method to add AI Integration using VectorDB
        /// </summary>
        /// <param name="dbIntegrationName"></param>
        /// <param name="provider"></param>
        /// <param name="indices"></param>
        /// <param name="config"></param>
        /// <param name="description"></param>
        /// <param name="overwrite"></param>
        /// <exception cref="Exception"></exception>
        public void AddVectorStore(string dbIntegrationName, VectorDBEnum provider, List<string> indices, IntegrationConfig config, string description = null, bool overwrite = false)
        {
            try
            {
                var vectorDb = new IntegrationUpdate();
                vectorDb.Configuration = config.ToDictionary();
                vectorDb.Type = provider.ToString();
                vectorDb.Category = IntegrationUpdate.CategoryEnum.VECTORDB;
                vectorDb.Enabled = true;
                vectorDb.Description = description;
                var existingIntegration = _integrationResourceApi.GetIntegrationProvider(dbIntegrationName);
                if (existingIntegration == null || overwrite)
                    _integrationResourceApi.SaveIntegrationProvider(vectorDb, dbIntegrationName);
                foreach (var index in indices)
                {
                    var apiDetails = new IntegrationApiUpdate();
                    apiDetails.Enabled = true;
                    apiDetails.Description = description;
                    var existingIntegrationApi = _integrationResourceApi.GetIntegrationApi(dbIntegrationName, index);
                    if (existingIntegrationApi == null || overwrite)
                        _integrationResourceApi.SaveIntegrationApi(apiDetails, index, dbIntegrationName);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(Constants.ADD_AI_INTEGRATION_ERROR_MESSAGE, ex.Message);
                throw new Exception(errorMessage, ex);
            }
        }

        /// <summary>
        /// Method to get token used for integration provider
        /// </summary>
        /// <param name="aiIntegration"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Dictionary<string, string> GetTokenUsed(string aiIntegration)
        {
            try
            {
                return _integrationResourceApi.GetTokenUsageForIntegrationProvider(aiIntegration);
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(Constants.GET_TOKEN_USED_BY_INTEGRATION_ERROR_MESSAGE, ex.Message);
                throw new Exception(errorMessage, ex);
            }
        }

        /// <summary>
        ///  Method to get token used by model
        /// </summary>
        /// <param name="aiIntegration"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int? GetTokenUsedByModel(string aiIntegration, string model)
        {
            try
            {
                return _integrationResourceApi.GetTokenUsageForIntegration(aiIntegration, model);
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format(Constants.GET_TOKEN_USED_BY_MODEL_ERROR_MESSAGE, ex.Message);
                throw new Exception(errorMessage, ex);
            }
        }

        /// <summary>
        /// Method to save IntegrationApi's
        /// </summary>
        /// <param name="aiIntegrationName"></param>
        /// <param name="models"></param>
        /// <param name="description"></param>
        /// <param name="overwrite"></param>
        private void SaveIntegrationApis(string aiIntegrationName, List<string> models, string description, bool overwrite)
        {
            foreach (var model in models)
            {
                var apiDetails = new IntegrationApiUpdate
                {
                    Enabled = true,
                    Description = description
                };

                var existingIntegrationApi = _integrationResourceApi.GetIntegrationApi(aiIntegrationName, model);

                if (existingIntegrationApi == null || overwrite)
                {
                    _integrationResourceApi.SaveIntegrationApi(apiDetails, model, aiIntegrationName);
                }
            }
        }
    }
}