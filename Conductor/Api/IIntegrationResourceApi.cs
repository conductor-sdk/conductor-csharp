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
using Conductor.Client;
using Conductor.Client.Models;
using System.Collections.Generic;
using EventLog = Conductor.Client.Models.EventLog;
using ThreadTask = System.Threading.Tasks;

namespace conductor_csharp.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IIntegrationResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Associate a Prompt Template with an Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <param name="promptName"></param>
        /// <returns></returns>
        void AssociatePromptWithIntegration(string integrationProvider, string integrationName, string promptName);

        /// <summary>
        /// Delete an Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns></returns>
        void DeleteIntegrationApi(string name, string integrationName);

        /// <summary>
        /// Delete an Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns></returns>
        void DeleteIntegrationProvider(string name);

        /// <summary>
        /// Delete a tag for Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <param name="integrationName">The name of the model associated with the tag.</param>
        /// <returns></returns>
        void DeleteTagForIntegration(List<Tag> body, string name, string integrationName);

        /// <summary>
        /// Delete a tag for Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <returns></returns>
        void DeleteTagForIntegrationProvider(List<Tag> body, string name);

        /// <summary>
        /// Get Integration details
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>IntegrationApi</returns>
        IntegrationApi GetIntegrationApi(string name, string integrationName);

        /// <summary>
        /// Get Integrations of an Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>List<IntegrationApi></returns>
        List<IntegrationApi> GetIntegrationApis(string name, bool? activeOnly = null);

        /// <summary>
        /// Get Integrations Available for an Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>List<string></returns>
        List<string> GetIntegrationAvailableApis(string name);

        /// <summary>
        /// Get Integration provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Integration</returns>
        Integration GetIntegrationProvider(string name);

        /// <summary>
        /// Get all Integrations Providers
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="category"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>List<Integration></returns>
        List<Integration> GetIntegrationProviders(string category = null, bool? activeOnly = null);

        /// <summary>
        /// Get the list of prompt templates associated with an integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <returns>List<MessageTemplate></returns>
        List<MessageTemplate> GetPromptsWithIntegration(string integrationProvider, string integrationName);

        /// <summary>
        /// Get Integrations Providers and Integrations combo
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="type"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>List<string></returns>
        List<string> GetProvidersAndIntegrations(string type = null, bool? activeOnly = null);

        /// <summary>
        /// Get tags by Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>List<Tag></returns>
        List<Tag> GetTagsForIntegration(string name, string integrationName);

        /// <summary>
        /// Get tags by Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>List<Tag></returns>
        List<Tag> GetTagsForIntegrationProvider(string name);

        /// <summary>
        /// Get Token Usage by Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>int?</returns>
        int? GetTokenUsageForIntegration(string name, string integrationName);

        /// <summary>
        /// Get Token Usage by Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Dictionary<string, string></returns>
        Dictionary<string, string> GetTokenUsageForIntegrationProvider(string name);

        /// <summary>
        /// Put a tag to Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <param name="integrationName">The name of the model to associate the tag with.</param>
        /// <returns></returns>
        void PutTagForIntegration(List<Tag> body, string name, string integrationName);

        /// <summary>
        /// Put a tag to Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <returns></returns>
        void PutTagForIntegrationProvider(List<Tag> body, string name);

        /// <summary>
        /// Record Event Stats
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        void RecordEventStats(List<EventLog> body, string type);

        /// <summary>
        /// Register Token usage
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns></returns>
        void RegisterTokenUsage(int? body, string name, string integrationName);

        /// <summary>
        /// Create or Update Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns></returns>
        void SaveIntegrationApi(IntegrationApiUpdate body, string name, string integrationName);

        /// <summary>
        /// Create or Update Integration provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        void SaveIntegrationProvider(IntegrationUpdate body, string name);

        #endregion Synchronous Operations

        #region Asynchronous Operations
        /// <summary>
        /// Associate a Prompt Template with an Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <param name="promptName"></param>
        /// <returns>Task of void</returns>
        ThreadTask.Task AssociatePromptWithIntegrationAsync(string integrationProvider, string integrationName, string promptName);

        /// <summary>
        /// Delete an Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of void</returns>
        ThreadTask.Task DeleteIntegrationApiAsync(string name, string integrationName);

        /// <summary>
        /// Delete an Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of void</returns>
        ThreadTask.Task DeleteIntegrationProviderAsync(string name);

        /// <summary>
        /// Delete a tag for Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <param name="integrationName">The name of the model associated with the tag.</param>
        /// <returns>Task of void</returns>
        ThreadTask.Task DeleteTagForIntegrationAsync(List<Tag> body, string name, string integrationName);

        /// <summary>
        /// Delete a tag for Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the integration associated with the tag</param>
        /// <returns>Task of void</returns>
        ThreadTask.Task DeleteTagForIntegrationProviderAsync(List<Tag> body, string name);

        /// <summary>
        /// Get Integration details
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of IntegrationApi</returns>
        ThreadTask.Task<IntegrationApi> GetIntegrationApiAsync(string name, string integrationName);

        /// <summary>
        /// Get Integrations of an Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>Task of List<IntegrationApi></returns>
        ThreadTask.Task<List<IntegrationApi>> GetIntegrationApisAsync(string name, bool? activeOnly = null);

        /// <summary>
        /// Get Integrations Available for an Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of List<string></returns>
        ThreadTask.Task<List<string>> GetIntegrationAvailableApisAsync(string name);

        /// <summary>
        /// Get Integration provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of Integration</returns>
        ThreadTask.Task<Integration> GetIntegrationProviderAsync(string name);

        /// <summary>
        /// Get Integration provider definitions
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List<IntegrationDef></returns>
        ThreadTask.Task<List<IntegrationDef>> GetIntegrationProviderDefsAsync();

        /// <summary>
        /// Get all Integrations Providers
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="category"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>Task of List<Integration></returns>
        ThreadTask.Task<List<Integration>> GetIntegrationProvidersAsync(string category = null, bool? activeOnly = null);

        /// <summary>
        /// Get the list of prompt templates associated with an integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="integrationProvider"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of List<MessageTemplate></returns>
        ThreadTask.Task<List<MessageTemplate>> GetPromptsWithIntegrationAsync(string integrationProvider, string integrationName);

        /// <summary>
        /// Get Integrations Providers and Integrations combo
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="type"> (optional)</param>
        /// <param name="activeOnly"> (optional, default to true)</param>
        /// <returns>Task of List<string></returns>
        ThreadTask.Task<List<string>> GetProvidersAndIntegrationsAsync(string type = null, bool? activeOnly = null);

        /// <summary>
        /// Get tags by Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of List<Tag></returns>
        ThreadTask.Task<List<Tag>> GetTagsForIntegrationAsync(string name, string integrationName);

        /// <summary>
        /// Get tags by Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of List<Tag></returns>
        ThreadTask.Task<List<Tag>> GetTagsForIntegrationProviderAsync(string name);

        /// <summary>
        /// Get Token Usage by Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of int?</returns>
        ThreadTask.Task<int?> GetTokenUsageForIntegrationAsync(string name, string integrationName);

        /// <summary>
        /// Get Token Usage by Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of Dictionary<string, string></returns>
        ThreadTask.Task<Dictionary<string, string>> GetTokenUsageForIntegrationProviderAsync(string name);

        /// <summary>
        /// Put a tag to Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <param name="integrationName">The name of the model to associate the tag with.</param>
        /// <returns>Task of void</returns>
        ThreadTask.Task PutTagForIntegrationAsync(List<Tag> body, string name, string integrationName);

        /// <summary>
        /// Put a tag to Integration Provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the integration to associate the tag with.</param>
        /// <returns>Task of void</returns>
        ThreadTask.Task PutTagForIntegrationProviderAsync(List<Tag> body, string name);

        /// <summary>
        /// Record Event Stats
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="type"></param>
        /// <returns>Task of void</returns>
        ThreadTask.Task RecordEventStatsAsync(List<EventLog> body, string type);

        /// <summary>
        /// Register Token usage
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of void</returns>
        ThreadTask.Task RegisterTokenUsageAsync(int? body, string name, string integrationName);

        /// <summary>
        /// Create or Update Integration
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <param name="integrationName"></param>
        /// <returns>Task of void</returns>
        ThreadTask.Task SaveIntegrationApiAsync(IntegrationApiUpdate body, string name, string integrationName);

        /// <summary>
        /// Create or Update Integration provider
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="name"></param>
        /// <returns>Task of void</returns>
        ThreadTask.Task SaveIntegrationProviderAsync(IntegrationUpdate body, string name);
        #endregion Asynchronous Operations
    }
}
