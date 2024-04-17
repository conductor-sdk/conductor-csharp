using Conductor.Client;
using Conductor.Definition.TaskType.LlmTasks.Utils;
using System.Collections.Generic;

namespace Conductor.Definition.TaskType.LlmTasks
{
    /// <summary>
    /// LlmIndexDocuments
    /// </summary>
    public class LlmIndexDocuments : Task
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
        /// Gets or Sets NameSpace
        /// </summary>
        public string NameSpace { get; set; }

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
        public EmbeddingModel EmbeddingModel { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets MediaType
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// Gets or Sets MetaData
        /// </summary>
        public Dictionary<string, object> MetaData { get; set; }

        /// <summary>
        /// Gets or Sets ChunkSize
        /// </summary>
        public int? ChunkSize { get; set; }

        /// <summary>
        /// Gets or Sets ChunkOverlap
        /// </summary>
        public int? ChunkOverlap { get; set; }

        /// <summary>
        /// Gets or Sets DocId
        /// </summary>
        public string DocId { get; set; }

        /// <summary>
        /// Gets or Sets TaskName
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LlmIndexDocuments" /> class
        /// </summary>
        /// <param name="taskReferenceName"></param>
        /// <param name="vectorDB"></param>
        /// <param name="nameSpace"></param>
        /// <param name="index"></param>
        /// <param name="embeddingModelProvider"></param>
        /// <param name="embeddingModel"></param>
        /// <param name="url"></param>
        /// <param name="mediaType"></param>
        /// <param name="chunkSize"></param>
        /// <param name="chunkOverlap"></param>
        /// <param name="docId"></param>
        /// <param name="taskName"></param>
        /// <param name="metaData"></param>
        public LlmIndexDocuments(string taskReferenceName = default(string), string vectorDB = default(string), string nameSpace = default(string), string index = default(string), string embeddingModelProvider = default(string), EmbeddingModel embeddingModel = default(EmbeddingModel), string url = default(string),
        string mediaType = default(string), int? chunkSize = default(int?), int? chunkOverlap = default(int?), string docId = default(string), string taskName = null, Dictionary<string, object> metaData = null) : base(taskReferenceName, WorkflowTaskTypeEnum.LLMINDEXDOCUMENT)
        {
            TaskRefName = taskReferenceName;
            VectorDB = vectorDB;
            NameSpace = nameSpace;
            Index = index;
            EmbeddingModelProvider = embeddingModelProvider;
            EmbeddingModel = embeddingModel;
            Url = url;
            MediaType = mediaType;
            MetaData = metaData;
            ChunkSize = chunkSize;
            ChunkOverlap = chunkOverlap;
            DocId = docId;
            TaskName = taskName ?? Constants.LLM_INDEX_DOCUMENT_TASKNAME;

            InitializeInputs();
        }

        /// <summary>
        /// Populates inputParams dictionary with LlmIndexDocuments attributes.
        /// </summary>
        private void InitializeInputs()
        {
            if (ChunkSize.HasValue)
            {
                WithInput(Constants.CHUNKSIZE, ChunkSize);
            }

            if (ChunkOverlap.HasValue)
            {
                WithInput(Constants.CHUNKOVERLAP, ChunkOverlap);
            }

            if (!string.IsNullOrEmpty(DocId))
            {
                WithInput(Constants.DOCID, DocId);
            }

            WithInput(Constants.VECTORDB, VectorDB);
            WithInput(Constants.NAMESPACE, NameSpace);
            WithInput(Constants.INDEX, Index);
            WithInput(Constants.EMBEDDING_MODEL_PROVIDER, EmbeddingModelProvider);
            WithInput(Constants.EMBEDDING_MODEL, EmbeddingModel);
            WithInput(Constants.URL, Url);
            WithInput(Constants.MEDIATYPE, MediaType);
            WithInput(Constants.METADATA, MetaData);
        }
    }
}