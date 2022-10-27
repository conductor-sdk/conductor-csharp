# IO.Swagger.Api.TaskResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**All**](TaskResourceApi.md#all) | **GET** /api/tasks/queue/all | Get the details about each queue
[**AllVerbose**](TaskResourceApi.md#allverbose) | **GET** /api/tasks/queue/all/verbose | Get the details about each queue
[**BatchPoll**](TaskResourceApi.md#batchpoll) | **GET** /api/tasks/poll/batch/{tasktype} | Batch poll for a task of a certain type
[**GetAllPollData**](TaskResourceApi.md#getallpolldata) | **GET** /api/tasks/queue/polldata/all | Get the last poll data for all task types
[**GetExternalStorageLocation1**](TaskResourceApi.md#getexternalstoragelocation1) | **GET** /api/tasks/externalstoragelocation | Get the external uri where the task payload is to be stored
[**GetPollData**](TaskResourceApi.md#getpolldata) | **GET** /api/tasks/queue/polldata | Get the last poll data for a given task type
[**GetTask**](TaskResourceApi.md#gettask) | **GET** /api/tasks/{taskId} | Get task by Id
[**GetTaskLogs**](TaskResourceApi.md#gettasklogs) | **GET** /api/tasks/{taskId}/log | Get Task Execution Logs
[**Log**](TaskResourceApi.md#log) | **POST** /api/tasks/{taskId}/log | Log Task Execution Details
[**Poll**](TaskResourceApi.md#poll) | **GET** /api/tasks/poll/{tasktype} | Poll for a task of a certain type
[**RequeuePendingTask**](TaskResourceApi.md#requeuependingtask) | **POST** /api/tasks/queue/requeue/{taskType} | Requeue pending tasks
[**Search1**](TaskResourceApi.md#search1) | **GET** /api/tasks/search | Search for tasks based in payload and other parameters
[**SearchV21**](TaskResourceApi.md#searchv21) | **GET** /api/tasks/search-v2 | Search for tasks based in payload and other parameters
[**Size**](TaskResourceApi.md#size) | **GET** /api/tasks/queue/sizes | Get Task type queue sizes
[**UpdateTask**](TaskResourceApi.md#updatetask) | **POST** /api/tasks | Update a task
[**UpdateTask1**](TaskResourceApi.md#updatetask1) | **POST** /api/tasks/{workflowId}/{taskRefName}/{status} | Update a task By Ref Name

<a name="all"></a>
# **All**
> Dictionary<string, long?> All ()

Get the details about each queue

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AllExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();

            try
            {
                // Get the details about each queue
                Dictionary&lt;string, long?&gt; result = apiInstance.All();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.All: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Dictionary<string, long?>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="allverbose"></a>
# **AllVerbose**
> Dictionary<string, Dictionary<string, Dictionary<string, long?>>> AllVerbose ()

Get the details about each queue

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AllVerboseExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();

            try
            {
                // Get the details about each queue
                Dictionary&lt;string, Dictionary&lt;string, Dictionary&lt;string, long?&gt;&gt;&gt; result = apiInstance.AllVerbose();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.AllVerbose: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Dictionary<string, Dictionary<string, Dictionary<string, long?>>>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="batchpoll"></a>
# **BatchPoll**
> List<Task> BatchPoll (string tasktype, string workerid = null, string domain = null, int? count = null, int? timeout = null)

Batch poll for a task of a certain type

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class BatchPollExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var tasktype = tasktype_example;  // string | 
            var workerid = workerid_example;  // string |  (optional) 
            var domain = domain_example;  // string |  (optional) 
            var count = 56;  // int? |  (optional)  (default to 1)
            var timeout = 56;  // int? |  (optional)  (default to 100)

            try
            {
                // Batch poll for a task of a certain type
                List&lt;Task&gt; result = apiInstance.BatchPoll(tasktype, workerid, domain, count, timeout);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.BatchPoll: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **tasktype** | **string**|  | 
 **workerid** | **string**|  | [optional] 
 **domain** | **string**|  | [optional] 
 **count** | **int?**|  | [optional] [default to 1]
 **timeout** | **int?**|  | [optional] [default to 100]

### Return type

[**List<Task>**](Task.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getallpolldata"></a>
# **GetAllPollData**
> List<PollData> GetAllPollData ()

Get the last poll data for all task types

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAllPollDataExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();

            try
            {
                // Get the last poll data for all task types
                List&lt;PollData&gt; result = apiInstance.GetAllPollData();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.GetAllPollData: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<PollData>**](PollData.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getexternalstoragelocation1"></a>
# **GetExternalStorageLocation1**
> ExternalStorageLocation GetExternalStorageLocation1 (string path, string operation, string payloadType)

Get the external uri where the task payload is to be stored

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetExternalStorageLocation1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var path = path_example;  // string | 
            var operation = operation_example;  // string | 
            var payloadType = payloadType_example;  // string | 

            try
            {
                // Get the external uri where the task payload is to be stored
                ExternalStorageLocation result = apiInstance.GetExternalStorageLocation1(path, operation, payloadType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.GetExternalStorageLocation1: " + e.Message );
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
<a name="getpolldata"></a>
# **GetPollData**
> List<PollData> GetPollData (string taskType)

Get the last poll data for a given task type

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetPollDataExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var taskType = taskType_example;  // string | 

            try
            {
                // Get the last poll data for a given task type
                List&lt;PollData&gt; result = apiInstance.GetPollData(taskType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.GetPollData: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **taskType** | **string**|  | 

### Return type

[**List<PollData>**](PollData.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettask"></a>
# **GetTask**
> Task GetTask (string taskId)

Get task by Id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTaskExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var taskId = taskId_example;  // string | 

            try
            {
                // Get task by Id
                Task result = apiInstance.GetTask(taskId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.GetTask: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **taskId** | **string**|  | 

### Return type

[**Task**](Task.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettasklogs"></a>
# **GetTaskLogs**
> List<TaskExecLog> GetTaskLogs (string taskId)

Get Task Execution Logs

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTaskLogsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var taskId = taskId_example;  // string | 

            try
            {
                // Get Task Execution Logs
                List&lt;TaskExecLog&gt; result = apiInstance.GetTaskLogs(taskId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.GetTaskLogs: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **taskId** | **string**|  | 

### Return type

[**List<TaskExecLog>**](TaskExecLog.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="log"></a>
# **Log**
> void Log (string body, string taskId)

Log Task Execution Details

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LogExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var body = new string(); // string | 
            var taskId = taskId_example;  // string | 

            try
            {
                // Log Task Execution Details
                apiInstance.Log(body, taskId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.Log: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**string**](string.md)|  | 
 **taskId** | **string**|  | 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="poll"></a>
# **Poll**
> Task Poll (string tasktype, string workerid = null, string domain = null)

Poll for a task of a certain type

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PollExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var tasktype = tasktype_example;  // string | 
            var workerid = workerid_example;  // string |  (optional) 
            var domain = domain_example;  // string |  (optional) 

            try
            {
                // Poll for a task of a certain type
                Task result = apiInstance.Poll(tasktype, workerid, domain);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.Poll: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **tasktype** | **string**|  | 
 **workerid** | **string**|  | [optional] 
 **domain** | **string**|  | [optional] 

### Return type

[**Task**](Task.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="requeuependingtask"></a>
# **RequeuePendingTask**
> string RequeuePendingTask (string taskType)

Requeue pending tasks

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RequeuePendingTaskExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var taskType = taskType_example;  // string | 

            try
            {
                // Requeue pending tasks
                string result = apiInstance.RequeuePendingTask(taskType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.RequeuePendingTask: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **taskType** | **string**|  | 

### Return type

**string**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="search1"></a>
# **Search1**
> SearchResultTaskSummary Search1 (int? start = null, int? size = null, string sort = null, string freeText = null, string query = null)

Search for tasks based in payload and other parameters

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
    public class Search1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var start = 56;  // int? |  (optional)  (default to 0)
            var size = 56;  // int? |  (optional)  (default to 100)
            var sort = sort_example;  // string |  (optional) 
            var freeText = freeText_example;  // string |  (optional)  (default to *)
            var query = query_example;  // string |  (optional) 

            try
            {
                // Search for tasks based in payload and other parameters
                SearchResultTaskSummary result = apiInstance.Search1(start, size, sort, freeText, query);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.Search1: " + e.Message );
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

[**SearchResultTaskSummary**](SearchResultTaskSummary.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="searchv21"></a>
# **SearchV21**
> SearchResultTask SearchV21 (int? start = null, int? size = null, string sort = null, string freeText = null, string query = null)

Search for tasks based in payload and other parameters

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
    public class SearchV21Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var start = 56;  // int? |  (optional)  (default to 0)
            var size = 56;  // int? |  (optional)  (default to 100)
            var sort = sort_example;  // string |  (optional) 
            var freeText = freeText_example;  // string |  (optional)  (default to *)
            var query = query_example;  // string |  (optional) 

            try
            {
                // Search for tasks based in payload and other parameters
                SearchResultTask result = apiInstance.SearchV21(start, size, sort, freeText, query);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.SearchV21: " + e.Message );
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

[**SearchResultTask**](SearchResultTask.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="size"></a>
# **Size**
> Dictionary<string, int?> Size (List<string> taskType = null)

Get Task type queue sizes

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SizeExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var taskType = new List<string>(); // List<string> |  (optional) 

            try
            {
                // Get Task type queue sizes
                Dictionary&lt;string, int?&gt; result = apiInstance.Size(taskType);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.Size: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **taskType** | [**List&lt;string&gt;**](string.md)|  | [optional] 

### Return type

**Dictionary<string, int?>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="updatetask"></a>
# **UpdateTask**
> string UpdateTask (TaskResult body)

Update a task

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateTaskExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var body = new TaskResult(); // TaskResult | 

            try
            {
                // Update a task
                string result = apiInstance.UpdateTask(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.UpdateTask: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**TaskResult**](TaskResult.md)|  | 

### Return type

**string**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="updatetask1"></a>
# **UpdateTask1**
> string UpdateTask1 (Dictionary<string, Object> body, string workflowId, string taskRefName, string status)

Update a task By Ref Name

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateTask1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TaskResourceApi();
            var body = new Dictionary<string, Object>(); // Dictionary<string, Object> | 
            var workflowId = workflowId_example;  // string | 
            var taskRefName = taskRefName_example;  // string | 
            var status = status_example;  // string | 

            try
            {
                // Update a task By Ref Name
                string result = apiInstance.UpdateTask1(body, workflowId, taskRefName, status);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TaskResourceApi.UpdateTask1: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**Dictionary&lt;string, Object&gt;**](Dictionary&lt;string, Object&gt;.md)|  | 
 **workflowId** | **string**|  | 
 **taskRefName** | **string**|  | 
 **status** | **string**|  | 

### Return type

**string**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
