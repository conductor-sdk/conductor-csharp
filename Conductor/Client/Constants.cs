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
namespace Conductor.Client
{
    /// <summary>
    /// Global level constant variables
    /// </summary>
    public static class Constants
    {
        //Authentication Keys
        public const string KEY_ID = "<REPLACE_WITH_KEY_ID>";
        public const string KEY_SECRET = "<REPLACE_WITH_KEY_SECRET>";
        public const string OWNER_EMAIL = "<REPLACE_WITH_OWNER_EMAIL>";
        public const int REST_CLIENT_REQUEST_TIME_OUT = 20000;
        public const int MAX_TOKEN_REFRESH_RETRY_COUNT = 3;

        //Error Messages
        public const string ADD_AI_INTEGRATION_ERROR_MESSAGE = "Failed to Add AI Integration: {0}";
        public const string ADD_PROMPT_TEMPLATE_ERROR_MESSAGE = "Failed to Add Prompt Template : {0}";
        public const string ASSOCIATE_PROMPT_TEMPLATE_ERROR_MESSAGE = "Failed to Associate a Prompt Template : {0}";
        public const string GET_PROMPT_TEMPLATE_ERROR_MESSAGE = "Failed to get Prompt Template: {0}";
        public const string GET_TOKEN_USED_BY_INTEGRATION_ERROR_MESSAGE = "Failed to get Token Used By Integration Provider: {0}";
        public const string GET_TOKEN_USED_BY_MODEL_ERROR_MESSAGE = "Failed to get Token Used By Model: {0}";
        public const string TEST_MESSAGE_TEMPLATE_ERROR_MESSAGE = "Failed to Test a Prompt Template : {0}";

        //Llm Task keys
        public const string LLM_GENERATE_EMBEDDINGS = "llm_generate_embeddings";
        public const string LLM_INDEX_DOCUMENT_TASKNAME = "llm_index_document";
        public const string LLM_INDEX_TEXT_TASKNAME = "llm_index_text";
        public const string LLM_TEXT_COMPLETE = "llm_text_complete";

        //String Keys
        public const string APIKEY = "api_key";
        public const string CHUNKOVERLAP = "chunkOverlap";
        public const string CHUNKSIZE = "chunkSize";
        public const string DOCID = "docId";
        public const string EMBEDDING_MODEL = "embeddingModel";
        public const string EMBEDDING_MODEL_PROVIDER = "embeddingModelProvider";
        public const string EMBEDDINGS = "embeddings";
        public const string ENDPOINT = "endpoint";
        public const string ENVIRONMENT = "environment";
        public const string INDEX = "index";
        public const string INSTRUCTIONTEMPLATE = "instructionTemplate";
        public const string LLM_QUERY_EMBEDDING_TASKNAME = "llm_get_embeddings";
        public const string LLMPROVIDER = "llmProvider";
        public const string MAXRESULTS = "maxResults";
        public const string MAXTOKENS = "maxTokens";
        public const string MEDIATYPE = "mediaType";
        public const string MESSAGES = "messages";
        public const string METADATA = "docId";
        public const string MODEL = "model";
        public const string NAMESPACE = "nameSpace";
        public const string PROJECTNAME = "projectName";
        public const string PROMPTNAME = "promptName";
        public const string PROMPTVARIABLES = "promptVariables";
        public const string QUERY = "query";
        public const string STOPWORDS = "stopWords";
        public const string TASK_NAME = "taskName";
        public const string TEMPERATURE = "temperature";
        public const string TEXT = "text";
        public const string TOPP = "topP";
        public const string URL = "url";
        public const string VECTORDB = "vectorDB";
        public const string PROMPTTESTWORKFLOWDEFAULTNAME = "prompt_test_";

        //LLM Environment Variables
        public const string PINECONEPROJECT = "PINECONE_PROJECT";
        public const string PINECONEENV = "PINECONE_ENV";
        public const string PINECONEENDPOINT = "PINECONE_ENDPOINT";
        public const string PINECONEAPIKEY = "PINECONE_API_KEY";
        public const string OPENAIAPIKEY = "OPENAI_API_KEY";

        //Annotation
        public const string TOKENCANCELLATION = "Token Requested Cancel";
        public const string RUNTIMEERROR = "Method failed with runtime error";
    }
}