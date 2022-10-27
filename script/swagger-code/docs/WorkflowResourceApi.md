# IO.Swagger.Api.WorkflowResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Decide**](WorkflowResourceApi.md#decide) | **PUT** /api/workflow/decide/{workflowId} | Starts the decision task for a workflow
[**Delete**](WorkflowResourceApi.md#delete) | **DELETE** /api/workflow/{workflowId}/remove | Removes the workflow from the system
[**ExecuteWorkflow**](WorkflowResourceApi.md#executeworkflow) | **POST** /api/workflow/execute/{name}/{version} | Execute a workflow synchronously
[**GetExecutionStatus**](WorkflowResourceApi.md#getexecutionstatus) | **GET** /api/workflow/{workflowId} | Gets the workflow by workflow id
[**GetExecutionStatusTaskList**](WorkflowResourceApi.md#getexecutionstatustasklist) | **GET** /api/workflow/{workflowId}/tasks | Gets the workflow tasks by workflow id
[**GetExternalStorageLocation**](WorkflowResourceApi.md#getexternalstoragelocation) | **GET** /api/workflow/externalstoragelocation | Get the uri and path of the external storage where the workflow payload is to be stored
[**GetRunningWorkflow**](WorkflowResourceApi.md#getrunningworkflow) | **GET** /api/workflow/running/{name} | Retrieve all the running workflows
[**GetWorkflowStatusSummary**](WorkflowResourceApi.md#getworkflowstatussummary) | **GET** /api/workflow/{workflowId}/status | Gets the workflow by workflow id
[**GetWorkflows**](WorkflowResourceApi.md#getworkflows) | **POST** /api/workflow/{name}/correlated | Lists workflows for the given correlation id list
[**GetWorkflows1**](WorkflowResourceApi.md#getworkflows1) | **GET** /api/workflow/{name}/correlated/{correlationId} | Lists workflows for the given correlation id
[**NotifyWorkflowCompletion**](WorkflowResourceApi.md#notifyworkflowcompletion) | **GET** /api/workflow/notifyWorkflowCompletion | 
[**PauseWorkflow**](WorkflowResourceApi.md#pauseworkflow) | **PUT** /api/workflow/{workflowId}/pause | Pauses the workflow
[**Rerun**](WorkflowResourceApi.md#rerun) | **POST** /api/workflow/{workflowId}/rerun | Reruns the workflow from a specific task
[**ResetWorkflow**](WorkflowResourceApi.md#resetworkflow) | **POST** /api/workflow/{workflowId}/resetcallbacks | Resets callback times of all non-terminal SIMPLE tasks to 0
[**Restart**](WorkflowResourceApi.md#restart) | **POST** /api/workflow/{workflowId}/restart | Restarts a completed workflow
[**ResumeWorkflow**](WorkflowResourceApi.md#resumeworkflow) | **PUT** /api/workflow/{workflowId}/resume | Resumes the workflow
[**Retry**](WorkflowResourceApi.md#retry) | **POST** /api/workflow/{workflowId}/retry | Retries the last failed task
[**Search**](WorkflowResourceApi.md#search) | **GET** /api/workflow/search | Search for workflows based on payload and other parameters
[**SearchV2**](WorkflowResourceApi.md#searchv2) | **GET** /api/workflow/search-v2 | Search for workflows based on payload and other parameters
[**SearchWorkflowsByTasks**](WorkflowResourceApi.md#searchworkflowsbytasks) | **GET** /api/workflow/search-by-tasks | Search for workflows based on task parameters
[**SearchWorkflowsByTasksV2**](WorkflowResourceApi.md#searchworkflowsbytasksv2) | **GET** /api/workflow/search-by-tasks-v2 | Search for workflows based on task parameters
[**SkipTaskFromWorkflow**](WorkflowResourceApi.md#skiptaskfromworkflow) | **PUT** /api/workflow/{workflowId}/skiptask/{taskReferenceName} | Skips a given task from a current running workflow
[**StartWorkflow**](WorkflowResourceApi.md#startworkflow) | **POST** /api/workflow | Start a new workflow with StartWorkflowRequest, which allows task to be executed in a domain
[**StartWorkflow1**](WorkflowResourceApi.md#startworkflow1) | **POST** /api/workflow/{name} | Start a new workflow. Returns the ID of the workflow instance that can be later used for tracking
[**Terminate1**](WorkflowResourceApi.md#terminate1) | **DELETE** /api/workflow/{workflowId} | Terminate workflow execution
[**UploadCompletedWorkflows**](WorkflowResourceApi.md#uploadcompletedworkflows) | **POST** /api/workflow/document-store/upload | Force upload all completed workflows to document store

<a name="decide"></a>
# **Decide**
> void Decide (string workflowId)

Starts the decision task for a workflow

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DecideExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 

            try
            {
                // Starts the decision task for a workflow
                apiInstance.Decide(workflowId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.Decide: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="delete"></a>
# **Delete**
> void Delete (string workflowId, bool? archiveWorkflow = null)

Removes the workflow from the system

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 
            var archiveWorkflow = true;  // bool? |  (optional)  (default to true)

            try
            {
                // Removes the workflow from the system
                apiInstance.Delete(workflowId, archiveWorkflow);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.Delete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 
 **archiveWorkflow** | **bool?**|  | [optional] [default to true]

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="executeworkflow"></a>
# **ExecuteWorkflow**
> WorkflowRun ExecuteWorkflow (StartWorkflowRequest body, string requestId, string name, int? version, string waitUntilTaskRef = null)

Execute a workflow synchronously

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ExecuteWorkflowExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var body = new StartWorkflowRequest(); // StartWorkflowRequest | 
            var requestId = requestId_example;  // string | 
            var name = name_example;  // string | 
            var version = 56;  // int? | 
            var waitUntilTaskRef = waitUntilTaskRef_example;  // string |  (optional) 

            try
            {
                // Execute a workflow synchronously
                WorkflowRun result = apiInstance.ExecuteWorkflow(body, requestId, name, version, waitUntilTaskRef);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.ExecuteWorkflow: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**StartWorkflowRequest**](StartWorkflowRequest.md)|  | 
 **requestId** | **string**|  | 
 **name** | **string**|  | 
 **version** | **int?**|  | 
 **waitUntilTaskRef** | **string**|  | [optional] 

### Return type

[**WorkflowRun**](WorkflowRun.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getexecutionstatus"></a>
# **GetExecutionStatus**
> Workflow GetExecutionStatus (string workflowId, bool? includeTasks = null, bool? summarize = null)

Gets the workflow by workflow id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetExecutionStatusExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 
            var includeTasks = true;  // bool? |  (optional)  (default to true)
            var summarize = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Gets the workflow by workflow id
                Workflow result = apiInstance.GetExecutionStatus(workflowId, includeTasks, summarize);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.GetExecutionStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 
 **includeTasks** | **bool?**|  | [optional] [default to true]
 **summarize** | **bool?**|  | [optional] [default to false]

### Return type

[**Workflow**](Workflow.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getexecutionstatustasklist"></a>
# **GetExecutionStatusTaskList**
> SearchResultTask GetExecutionStatusTaskList (string workflowId, int? start = null, int? count = null, string status = null)

Gets the workflow tasks by workflow id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetExecutionStatusTaskListExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 
            var start = 56;  // int? |  (optional)  (default to 0)
            var count = 56;  // int? |  (optional)  (default to 15)
            var status = status_example;  // string |  (optional) 

            try
            {
                // Gets the workflow tasks by workflow id
                SearchResultTask result = apiInstance.GetExecutionStatusTaskList(workflowId, start, count, status);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.GetExecutionStatusTaskList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 
 **start** | **int?**|  | [optional] [default to 0]
 **count** | **int?**|  | [optional] [default to 15]
 **status** | **string**|  | [optional] 

### Return type

[**SearchResultTask**](SearchResultTask.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getexternalstoragelocation"></a>
# **GetExternalStorageLocation**
> ExternalStorageLocation GetExternalStorageLocation (string path, string operation, string payloadType)

Get the uri and path of the external storage where the workflow payload is to be stored

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetExternalStorageLocationExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var path = path_example;  // string | 
            var operation = operation_example;  // string | 
            var payloadType = payloadType_example;  // string | 

            try
            {
                // Get the uri and path of the external storage where the workflow payload is to be stored
                ExternalStorageLocation result = apiInstance.GetExternalStorageLocation(path, operation, payloadType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.GetExternalStorageLocation: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **path** | **string**|  | 
 **operation** | **string**|  | 
 **payloadType** | **string**|  | 

### Return type

[**ExternalStorageLocation**](ExternalStorageLocation.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getrunningworkflow"></a>
# **GetRunningWorkflow**
> List<string> GetRunningWorkflow (string name, int? version = null, long? startTime = null, long? endTime = null)

Retrieve all the running workflows

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetRunningWorkflowExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var name = name_example;  // string | 
            var version = 56;  // int? |  (optional)  (default to 1)
            var startTime = 789;  // long? |  (optional) 
            var endTime = 789;  // long? |  (optional) 

            try
            {
                // Retrieve all the running workflows
                List&lt;string&gt; result = apiInstance.GetRunningWorkflow(name, version, startTime, endTime);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.GetRunningWorkflow: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **version** | **int?**|  | [optional] [default to 1]
 **startTime** | **long?**|  | [optional] 
 **endTime** | **long?**|  | [optional] 

### Return type

**List<string>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getworkflowstatussummary"></a>
# **GetWorkflowStatusSummary**
> WorkflowStatus GetWorkflowStatusSummary (string workflowId, bool? includeOutput = null, bool? includeVariables = null)

Gets the workflow by workflow id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWorkflowStatusSummaryExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 
            var includeOutput = true;  // bool? |  (optional)  (default to false)
            var includeVariables = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Gets the workflow by workflow id
                WorkflowStatus result = apiInstance.GetWorkflowStatusSummary(workflowId, includeOutput, includeVariables);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.GetWorkflowStatusSummary: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 
 **includeOutput** | **bool?**|  | [optional] [default to false]
 **includeVariables** | **bool?**|  | [optional] [default to false]

### Return type

[**WorkflowStatus**](WorkflowStatus.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getworkflows"></a>
# **GetWorkflows**
> Dictionary<string, List<Workflow>> GetWorkflows (List<string> body, string name, bool? includeClosed = null, bool? includeTasks = null)

Lists workflows for the given correlation id list

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWorkflowsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var body = new List<string>(); // List<string> | 
            var name = name_example;  // string | 
            var includeClosed = true;  // bool? |  (optional)  (default to false)
            var includeTasks = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Lists workflows for the given correlation id list
                Dictionary&lt;string, List&lt;Workflow&gt;&gt; result = apiInstance.GetWorkflows(body, name, includeClosed, includeTasks);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.GetWorkflows: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;string&gt;**](string.md)|  | 
 **name** | **string**|  | 
 **includeClosed** | **bool?**|  | [optional] [default to false]
 **includeTasks** | **bool?**|  | [optional] [default to false]

### Return type

**Dictionary<string, List<Workflow>>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getworkflows1"></a>
# **GetWorkflows1**
> List<Workflow> GetWorkflows1 (string name, string correlationId, bool? includeClosed = null, bool? includeTasks = null)

Lists workflows for the given correlation id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWorkflows1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var name = name_example;  // string | 
            var correlationId = correlationId_example;  // string | 
            var includeClosed = true;  // bool? |  (optional)  (default to false)
            var includeTasks = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Lists workflows for the given correlation id
                List&lt;Workflow&gt; result = apiInstance.GetWorkflows1(name, correlationId, includeClosed, includeTasks);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.GetWorkflows1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **correlationId** | **string**|  | 
 **includeClosed** | **bool?**|  | [optional] [default to false]
 **includeTasks** | **bool?**|  | [optional] [default to false]

### Return type

[**List<Workflow>**](Workflow.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="notifyworkflowcompletion"></a>
# **NotifyWorkflowCompletion**
> string NotifyWorkflowCompletion (string workflowId)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class NotifyWorkflowCompletionExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 

            try
            {
                string result = apiInstance.NotifyWorkflowCompletion(workflowId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.NotifyWorkflowCompletion: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 

### Return type

**string**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="pauseworkflow"></a>
# **PauseWorkflow**
> void PauseWorkflow (string workflowId)

Pauses the workflow

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PauseWorkflowExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 

            try
            {
                // Pauses the workflow
                apiInstance.PauseWorkflow(workflowId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.PauseWorkflow: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="rerun"></a>
# **Rerun**
> string Rerun (RerunWorkflowRequest body, string workflowId)

Reruns the workflow from a specific task

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RerunExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var body = new RerunWorkflowRequest(); // RerunWorkflowRequest | 
            var workflowId = workflowId_example;  // string | 

            try
            {
                // Reruns the workflow from a specific task
                string result = apiInstance.Rerun(body, workflowId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.Rerun: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**RerunWorkflowRequest**](RerunWorkflowRequest.md)|  | 
 **workflowId** | **string**|  | 

### Return type

**string**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="resetworkflow"></a>
# **ResetWorkflow**
> void ResetWorkflow (string workflowId)

Resets callback times of all non-terminal SIMPLE tasks to 0

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ResetWorkflowExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 

            try
            {
                // Resets callback times of all non-terminal SIMPLE tasks to 0
                apiInstance.ResetWorkflow(workflowId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.ResetWorkflow: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="restart"></a>
# **Restart**
> void Restart (string workflowId, bool? useLatestDefinitions = null)

Restarts a completed workflow

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RestartExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 
            var useLatestDefinitions = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Restarts a completed workflow
                apiInstance.Restart(workflowId, useLatestDefinitions);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.Restart: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 
 **useLatestDefinitions** | **bool?**|  | [optional] [default to false]

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="resumeworkflow"></a>
# **ResumeWorkflow**
> void ResumeWorkflow (string workflowId)

Resumes the workflow

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ResumeWorkflowExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 

            try
            {
                // Resumes the workflow
                apiInstance.ResumeWorkflow(workflowId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.ResumeWorkflow: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="retry"></a>
# **Retry**
> void Retry (string workflowId, bool? resumeSubworkflowTasks = null)

Retries the last failed task

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RetryExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 
            var resumeSubworkflowTasks = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Retries the last failed task
                apiInstance.Retry(workflowId, resumeSubworkflowTasks);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.Retry: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 
 **resumeSubworkflowTasks** | **bool?**|  | [optional] [default to false]

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="search"></a>
# **Search**
> ScrollableSearchResultWorkflowSummary Search (string queryId = null, int? start = null, int? size = null, string sort = null, string freeText = null, string query = null, bool? skipCache = null)

Search for workflows based on payload and other parameters

use sort options as sort=<field>:ASC|DESC e.g. sort=name&sort=workflowId:DESC. If order is not specified, defaults to ASC.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var queryId = queryId_example;  // string |  (optional) 
            var start = 56;  // int? |  (optional)  (default to 0)
            var size = 56;  // int? |  (optional)  (default to 100)
            var sort = sort_example;  // string |  (optional) 
            var freeText = freeText_example;  // string |  (optional)  (default to *)
            var query = query_example;  // string |  (optional) 
            var skipCache = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Search for workflows based on payload and other parameters
                ScrollableSearchResultWorkflowSummary result = apiInstance.Search(queryId, start, size, sort, freeText, query, skipCache);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.Search: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **queryId** | **string**|  | [optional] 
 **start** | **int?**|  | [optional] [default to 0]
 **size** | **int?**|  | [optional] [default to 100]
 **sort** | **string**|  | [optional] 
 **freeText** | **string**|  | [optional] [default to *]
 **query** | **string**|  | [optional] 
 **skipCache** | **bool?**|  | [optional] [default to false]

### Return type

[**ScrollableSearchResultWorkflowSummary**](ScrollableSearchResultWorkflowSummary.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="searchv2"></a>
# **SearchV2**
> SearchResultWorkflow SearchV2 (int? start = null, int? size = null, string sort = null, string freeText = null, string query = null)

Search for workflows based on payload and other parameters

use sort options as sort=<field>:ASC|DESC e.g. sort=name&sort=workflowId:DESC. If order is not specified, defaults to ASC.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchV2Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var start = 56;  // int? |  (optional)  (default to 0)
            var size = 56;  // int? |  (optional)  (default to 100)
            var sort = sort_example;  // string |  (optional) 
            var freeText = freeText_example;  // string |  (optional)  (default to *)
            var query = query_example;  // string |  (optional) 

            try
            {
                // Search for workflows based on payload and other parameters
                SearchResultWorkflow result = apiInstance.SearchV2(start, size, sort, freeText, query);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.SearchV2: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **start** | **int?**|  | [optional] [default to 0]
 **size** | **int?**|  | [optional] [default to 100]
 **sort** | **string**|  | [optional] 
 **freeText** | **string**|  | [optional] [default to *]
 **query** | **string**|  | [optional] 

### Return type

[**SearchResultWorkflow**](SearchResultWorkflow.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="searchworkflowsbytasks"></a>
# **SearchWorkflowsByTasks**
> SearchResultWorkflowSummary SearchWorkflowsByTasks (int? start = null, int? size = null, string sort = null, string freeText = null, string query = null)

Search for workflows based on task parameters

use sort options as sort=<field>:ASC|DESC e.g. sort=name&sort=workflowId:DESC. If order is not specified, defaults to ASC

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchWorkflowsByTasksExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var start = 56;  // int? |  (optional)  (default to 0)
            var size = 56;  // int? |  (optional)  (default to 100)
            var sort = sort_example;  // string |  (optional) 
            var freeText = freeText_example;  // string |  (optional)  (default to *)
            var query = query_example;  // string |  (optional) 

            try
            {
                // Search for workflows based on task parameters
                SearchResultWorkflowSummary result = apiInstance.SearchWorkflowsByTasks(start, size, sort, freeText, query);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.SearchWorkflowsByTasks: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **start** | **int?**|  | [optional] [default to 0]
 **size** | **int?**|  | [optional] [default to 100]
 **sort** | **string**|  | [optional] 
 **freeText** | **string**|  | [optional] [default to *]
 **query** | **string**|  | [optional] 

### Return type

[**SearchResultWorkflowSummary**](SearchResultWorkflowSummary.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="searchworkflowsbytasksv2"></a>
# **SearchWorkflowsByTasksV2**
> SearchResultWorkflow SearchWorkflowsByTasksV2 (int? start = null, int? size = null, string sort = null, string freeText = null, string query = null)

Search for workflows based on task parameters

use sort options as sort=<field>:ASC|DESC e.g. sort=name&sort=workflowId:DESC. If order is not specified, defaults to ASC

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SearchWorkflowsByTasksV2Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var start = 56;  // int? |  (optional)  (default to 0)
            var size = 56;  // int? |  (optional)  (default to 100)
            var sort = sort_example;  // string |  (optional) 
            var freeText = freeText_example;  // string |  (optional)  (default to *)
            var query = query_example;  // string |  (optional) 

            try
            {
                // Search for workflows based on task parameters
                SearchResultWorkflow result = apiInstance.SearchWorkflowsByTasksV2(start, size, sort, freeText, query);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.SearchWorkflowsByTasksV2: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **start** | **int?**|  | [optional] [default to 0]
 **size** | **int?**|  | [optional] [default to 100]
 **sort** | **string**|  | [optional] 
 **freeText** | **string**|  | [optional] [default to *]
 **query** | **string**|  | [optional] 

### Return type

[**SearchResultWorkflow**](SearchResultWorkflow.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="skiptaskfromworkflow"></a>
# **SkipTaskFromWorkflow**
> void SkipTaskFromWorkflow (string workflowId, string taskReferenceName, SkipTaskRequest skipTaskRequest)

Skips a given task from a current running workflow

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SkipTaskFromWorkflowExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 
            var taskReferenceName = taskReferenceName_example;  // string | 
            var skipTaskRequest = new SkipTaskRequest(); // SkipTaskRequest | 

            try
            {
                // Skips a given task from a current running workflow
                apiInstance.SkipTaskFromWorkflow(workflowId, taskReferenceName, skipTaskRequest);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.SkipTaskFromWorkflow: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 
 **taskReferenceName** | **string**|  | 
 **skipTaskRequest** | [**SkipTaskRequest**](SkipTaskRequest.md)|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="startworkflow"></a>
# **StartWorkflow**
> string StartWorkflow (StartWorkflowRequest body)

Start a new workflow with StartWorkflowRequest, which allows task to be executed in a domain

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StartWorkflowExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var body = new StartWorkflowRequest(); // StartWorkflowRequest | 

            try
            {
                // Start a new workflow with StartWorkflowRequest, which allows task to be executed in a domain
                string result = apiInstance.StartWorkflow(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.StartWorkflow: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**StartWorkflowRequest**](StartWorkflowRequest.md)|  | 

### Return type

**string**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="startworkflow1"></a>
# **StartWorkflow1**
> string StartWorkflow1 (Dictionary<string, Object> body, string name, int? version = null, string correlationId = null, int? priority = null)

Start a new workflow. Returns the ID of the workflow instance that can be later used for tracking

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StartWorkflow1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var body = new Dictionary<string, Object>(); // Dictionary<string, Object> | 
            var name = name_example;  // string | 
            var version = 56;  // int? |  (optional) 
            var correlationId = correlationId_example;  // string |  (optional) 
            var priority = 56;  // int? |  (optional)  (default to 0)

            try
            {
                // Start a new workflow. Returns the ID of the workflow instance that can be later used for tracking
                string result = apiInstance.StartWorkflow1(body, name, version, correlationId, priority);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.StartWorkflow1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**Dictionary&lt;string, Object&gt;**](Dictionary&lt;string, Object&gt;.md)|  | 
 **name** | **string**|  | 
 **version** | **int?**|  | [optional] 
 **correlationId** | **string**|  | [optional] 
 **priority** | **int?**|  | [optional] [default to 0]

### Return type

**string**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="terminate1"></a>
# **Terminate1**
> void Terminate1 (string workflowId, string reason = null)

Terminate workflow execution

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class Terminate1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();
            var workflowId = workflowId_example;  // string | 
            var reason = reason_example;  // string |  (optional) 

            try
            {
                // Terminate workflow execution
                apiInstance.Terminate1(workflowId, reason);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.Terminate1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workflowId** | **string**|  | 
 **reason** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="uploadcompletedworkflows"></a>
# **UploadCompletedWorkflows**
> Object UploadCompletedWorkflows ()

Force upload all completed workflows to document store

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UploadCompletedWorkflowsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new WorkflowResourceApi();

            try
            {
                // Force upload all completed workflows to document store
                Object result = apiInstance.UploadCompletedWorkflows();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkflowResourceApi.UploadCompletedWorkflows: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
