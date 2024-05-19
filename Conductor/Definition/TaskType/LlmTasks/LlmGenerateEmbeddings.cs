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

namespace Conductor.Definition.TaskType.LlmTasks
{
    /// <summary>
    /// LlmGenerateEmbeddings
    /// </summary>
    public class LlmGenerateEmbeddings : Task
    {
        /// <summary>
        /// Gets or Sets TaskName
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or Sets LlmProvider
        /// </summary>
        public string LlmProvider { get; set; }

        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or Sets Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LlmGenerateEmbeddings" /> class
        /// </summary>
        /// <param name="taskReferenceName"></param>
        /// <param name="llmProvider"></param>
        /// <param name="model"></param>
        /// <param name="text"></param>
        /// <param name="taskName"></param>
        public LlmGenerateEmbeddings(string taskReferenceName, string llmProvider, string model, string text, string taskName = null) : base(taskReferenceName, WorkflowTaskTypeEnum.LLMGENERATEEMBEDDINGS)
        {
            TaskName = taskName ?? Constants.LLM_GENERATE_EMBEDDINGS;
            LlmProvider = llmProvider;
            Model = model;
            Text = text;

            InitializeInputs();
        }

        /// <summary>
        /// Populates inputParams dictionary with LlmGenerateEmbeddings attributes.
        /// </summary>
        private void InitializeInputs()
        {
            WithInput(Constants.LLMPROVIDER, LlmProvider);
            WithInput(Constants.MODEL, Model);
            WithInput(Constants.TEXT, Text);
        }
    }
}