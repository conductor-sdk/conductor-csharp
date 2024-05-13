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

namespace conductor_csharp.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IPromptResourceApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns></returns>
        void DeleteMessageTemplate(string name);

        /// <summary>
        /// Delete a tag for Prompt Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the Prompt the tag should be deleted from.</param>
        /// <returns></returns>
        void DeleteTagForPromptTemplate(List<Tag> body, string name);

        /// <summary>
        /// Get Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>MessageTemplate</returns>
        MessageTemplate GetMessageTemplate(string name);

        /// <summary>
        /// Get Templates
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>List<MessageTemplate></returns>
        List<MessageTemplate> GetMessageTemplates();

        /// <summary>
        /// Get tags by Prompt Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>List<Tag></returns>
        List<Tag> GetTagsForPromptTemplate(string name);

        /// <summary>
        /// Put a tag to Prompt Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the Prompt the tag should be updated with.</param>
        /// <returns></returns>
        void PutTagForPromptTemplate(List<Tag> body, string name);

        /// <summary>
        /// Create or Update Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <param name="models"> (optional)</param>
        /// <returns></returns>
        void SaveMessageTemplate(string body, string description, string name, List<string> models = null);

        /// <summary>
        /// Test Prompt Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>string</returns>
        string TestMessageTemplate(PromptTemplateTestRequest body);

        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Delete Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteMessageTemplateAsync(string name);

        /// <summary>
        /// Delete a tag for Prompt Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be deleted.</param>
        /// <param name="name">The name of the Prompt the tag should be deleted from.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteTagForPromptTemplateAsync(List<Tag> body, string name);

        /// <summary>
        /// Get Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of MessageTemplate</returns>
        System.Threading.Tasks.Task<MessageTemplate> GetMessageTemplateAsync(string name);

        /// <summary>
        /// Get Templates
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of List<MessageTemplate></returns>
        System.Threading.Tasks.Task<List<MessageTemplate>> GetMessageTemplatesAsync();

        /// <summary>
        /// Get tags by Prompt Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="name"></param>
        /// <returns>Task of List<Tag></returns>
        System.Threading.Tasks.Task<List<Tag>> GetTagsForPromptTemplateAsync(string name);

        /// <summary>
        /// Put a tag to Prompt Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">The list of tags to be updated.</param>
        /// <param name="name">The name of the Prompt the tag should be updated with.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task PutTagForPromptTemplateAsync(List<Tag> body, string name);

        /// <summary>
        /// Create or Update Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <param name="models"> (optional)</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task SaveMessageTemplateAsync(string body, string description, string name, List<string> models = null);

        /// <summary>
        /// Test Prompt Template
        /// </summary>
        /// <remarks>
        ///
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"></param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> TestMessageTemplateAsync(PromptTemplateTestRequest body);
        #endregion Asynchronous Operations
    }
}
