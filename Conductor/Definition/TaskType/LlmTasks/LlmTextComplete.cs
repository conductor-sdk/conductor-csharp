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
using System.Collections.Generic;

namespace Conductor.Definition.TaskType.LlmTasks
{
    /// <summary>
    /// LlmTextCompare
    /// </summary>
    public class LlmTextComplete : Task
    {
        /// <summary>
        /// Gets or Sets TaskRefName
        /// </summary>
        public string TaskRefName { get; set; }

        /// <summary>
        /// Gets or Sets LlmProvider
        /// </summary>
        public string LlmProvider { get; set; }

        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or Sets PromptName
        /// </summary>
        public string PromptName { get; set; }

        /// <summary>
        /// Gets or Sets StopWords
        /// </summary>
        public List<string> StopWords { get; set; }

        /// <summary>
        /// Gets or Sets MaxTokens
        /// </summary>
        public int MaxTokens { get; set; }

        /// <summary>
        /// Gets or Sets Temperature
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Gets or Sets TopP
        /// </summary>
        public int TopP { get; set; }

        /// <summary>
        /// Gets or Sets TaskName
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or Sets TemplateVariables
        /// </summary>
        public Dictionary<string, object> TemplateVariables { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LlmTextComplete" /> class
        /// </summary>
        /// <param name="taskRefName"></param>
        /// <param name="llmProvider"></param>
        /// <param name="model"></param>
        /// <param name="promptName"></param>
        /// <param name="stopWords"></param>
        /// <param name="maxTokens"></param>
        /// <param name="temperature"></param>
        /// <param name="topP"></param>
        /// <param name="taskName"></param>
        /// <param name="templateVariables"></param>
        public LlmTextComplete(string taskRefName, string llmProvider, string model, string promptName,
                           List<string> stopWords = null, int maxTokens = 100, int temperature = 0, int topP = 1,
                           string taskName = null, Dictionary<string, object> templateVariables = null) : base(taskRefName, WorkflowTaskTypeEnum.LLMTEXTCOMPLETE)
        {
            TaskRefName = taskRefName;
            LlmProvider = llmProvider;
            Model = model;
            PromptName = promptName;
            StopWords = stopWords;
            Temperature = temperature;
            TopP = topP;
            MaxTokens = maxTokens;
            TaskName = taskName ?? Constants.LLM_TEXT_COMPLETE;
            TemplateVariables = templateVariables ?? new Dictionary<string, object>();

            InitializeInputs();
        }

        /// <summary>
        /// Adding PromptVariables to InputParams
        /// </summary>
        /// <param name="variables"></param>
        /// <returns></returns>
        public LlmTextComplete PromptVariables(Dictionary<string, object> variables)
        {
            foreach (var variable in variables)
            {
                TemplateVariables[variable.Key] = variable.Value;
            }
            WithInput(Constants.PROMPTVARIABLES, TemplateVariables);
            return this;
        }

        /// <summary>
        /// Adding PromptVariable to InputParams
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public LlmTextComplete PromptVariable(string variable, object value)
        {
            TemplateVariables[variable] = value;
            WithInput(Constants.PROMPTVARIABLES, TemplateVariables);
            return this;
        }

        /// <summary>
        /// Populates inputParams dictionary with LlmTextComplete attributes.
        /// </summary>
        private void InitializeInputs()
        {
            if (StopWords != null)
            {
                WithInput(Constants.STOPWORDS, StopWords);
            }

            if (MaxTokens != 0)
            {
                WithInput(Constants.MAXTOKENS, MaxTokens);
            }

            WithInput(Constants.LLMPROVIDER, LlmProvider);
            WithInput(Constants.MODEL, Model);
            WithInput(Constants.PROMPTNAME, PromptName);
            WithInput(Constants.TEMPERATURE, Temperature);
            WithInput(Constants.TOPP, TopP);
            WithInput(Constants.PROMPTVARIABLES, TemplateVariables);
        }
    }
}
