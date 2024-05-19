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
    /// LlmSearchIndex
    /// </summary>
    public class LlmSearchIndex : Task
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
        /// Gets or Sets Namespace
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or Sets Index
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// Gets or Sets EmbeddingModelProvider
        /// </summary>
        public string EmbeddingModelProvider { get; set; }

        /// <summary>
        /// Gets or Sets EmbeddingModel
        /// </summary>
        public string EmbeddingModel { get; set; }

        /// <summary>
        /// Gets or Sets Query
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Gets or Sets TaskName
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or Sets MaxResults
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LlmSearchIndex" /> class
        /// </summary>
        /// <param name="taskReferenceName"></param>
        /// <param name="vectorDB"></param>
        /// <param name="nameSpace"></param>
        /// <param name="index"></param>
        /// <param name="embeddingModelProvider"></param>
        /// <param name="embeddingModel"></param>
        /// <param name="query"></param>
        /// <param name="taskName"></param>
        /// <param name="MaxResults"></param>
        public LlmSearchIndex(string taskReferenceName, string vectorDB, string nameSpace, string index, string embeddingModelProvider,
            string embeddingModel, string query, string taskName = null, int MaxResults = 1) : base(taskReferenceName, WorkflowTaskTypeEnum.LLMSEARCHINDEX)
        {
            TaskReferenceName = taskReferenceName;
            VectorDB = vectorDB;
            Namespace = nameSpace;
            Index = index;
            EmbeddingModelProvider = embeddingModelProvider;
            EmbeddingModel = embeddingModel;
            Query = query;
            TaskName = taskName;

            InitializeInputs();
        }

        /// <summary>
        /// Populates inputParams dictionary with LlmSearchIndex attributes.
        /// </summary>
        private void InitializeInputs()
        {
            WithInput(Constants.VECTORDB, VectorDB);
            WithInput(Constants.NAMESPACE, Namespace);
            WithInput(Constants.INDEX, Index);
            WithInput(Constants.EMBEDDING_MODEL_PROVIDER, EmbeddingModelProvider);
            WithInput(Constants.EMBEDDING_MODEL, EmbeddingModel);
            WithInput(Constants.QUERY, Query);
            WithInput(Constants.MAXRESULTS, MaxResults);
        }
    }
}