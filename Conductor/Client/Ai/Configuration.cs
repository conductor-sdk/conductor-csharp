using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Conductor.Client.Ai
{
    public class Configuration
    {
        /// <summary>
        /// Defines LLMProvider
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LLMProviderEnum
        {
            /// <summary>
            /// Enum AZURE_OPEN_AI for value: azure_openai
            /// </summary>
            [EnumMember(Value = "azure_openai")]
            AZURE_OPEN_AI = 1,

            /// <summary>
            /// Enum OPEN_AI for value: openai
            /// </summary>
            [EnumMember(Value = "openai")]
            OPEN_AI = 2,

            /// <summary>
            /// Enum GCP_VERTEX_AI for value: vertex_ai
            /// </summary>
            [EnumMember(Value = "vertex_ai")]
            GCP_VERTEX_AI = 3,

            /// <summary>
            /// Enum HUGGING_FACE for value: huggingface
            /// </summary>
            [EnumMember(Value = "huggingface")]
            HUGGING_FACE = 4,
        }

        /// <summary>
        /// Defines VectorDB
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum VectorDBEnum
        {
            /// <summary>
            /// Enum PINECONE_DB for value: pineconedb
            /// </summary>
            [EnumMember(Value = "pineconedb")]
            PINECONE_DB = 1,

            /// <summary>
            /// Enum WEAVIATE_DB for value: weaviatedb
            /// </summary>
            [EnumMember(Value = "weaviatedb")]
            WEAVIATE_DB = 2,
        }
    }
}