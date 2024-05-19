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
    /// LlmQueryEmbeddings
    /// </summary>
    public class LlmQueryEmbeddings : Task
    {
        /// <summary>
        /// Gets or Sets TaskRefName
        /// </summary>
        public string TaskRefName { get; set; }

        /// <summary>
        /// Gets or Sets VectorDB
        /// </summary>
        public string VectorDB { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// Gets or Sets Embeddings
        /// </summary>
        public List<int> Embeddings { get; set; }

        /// <summary>
        /// Gets or Sets TaskName
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or Sets Namespace
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LlmQueryEmbeddings" /> class
        /// </summary>
        /// <param name="taskReferenceName"></param>
        /// <param name="vectorDB"></param>
        /// <param name="index"></param>
        /// <param name="embeddings"></param>
        /// <param name="taskName"></param>
        /// <param name="nameSpace"></param>
        public LlmQueryEmbeddings(string taskReferenceName, string vectorDB, string index, List<int> embeddings, string taskName = null, string nameSpace = null) : base(taskReferenceName, WorkflowTaskTypeEnum.LLMGETEMBEDDINGS)
        {
            TaskRefName = taskReferenceName;
            TaskName = taskName ?? Constants.LLM_QUERY_EMBEDDING_TASKNAME;
            VectorDB = vectorDB;
            Index = index;
            Embeddings = embeddings;
            Namespace = nameSpace;

            InitializeInputs();
        }

        /// <summary>
        /// Populates inputParams dictionary with LlmQueryEmbeddings attributes.
        /// </summary>
        private void InitializeInputs()
        {
            WithInput(Constants.VECTORDB, VectorDB);
            WithInput(Constants.NAMESPACE, Namespace);
            WithInput(Constants.INDEX, Index);
            WithInput(Constants.EMBEDDINGS, Embeddings);
        }
    }
}