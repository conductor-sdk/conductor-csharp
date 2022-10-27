# IO.Swagger.Api.AdminResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetRedisUsage**](AdminResourceApi.md#getredisusage) | **GET** /api/admin/redisUsage | Get details of redis usage
[**RequeueSweep**](AdminResourceApi.md#requeuesweep) | **POST** /api/admin/sweep/requeue/{workflowId} | Queue up all the running workflows for sweep
[**VerifyAndRepairWorkflowConsistency**](AdminResourceApi.md#verifyandrepairworkflowconsistency) | **POST** /api/admin/consistency/verifyAndRepair/{workflowId} | Verify and repair workflow consistency
[**View**](AdminResourceApi.md#view) | **GET** /api/admin/task/{tasktype} | Get the list of pending tasks for a given task type

<a name="getredisusage"></a>
# **GetRedisUsage**
> Dictionary<string, Object> GetRedisUsage ()

Get details of redis usage

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetRedisUsageExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new AdminResourceApi();

            try
            {
                // Get details of redis usage
                Dictionary&lt;string, Object&gt; result = apiInstance.GetRedisUsage();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminResourceApi.GetRedisUsage: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Dictionary<string, Object>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="requeuesweep"></a>
# **RequeueSweep**
> string RequeueSweep (string workflowId)

Queue up all the running workflows for sweep

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RequeueSweepExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new AdminResourceApi();
            var workflowId = workflowId_example;  // string | 

            try
            {
                // Queue up all the running workflows for sweep
                string result = apiInstance.RequeueSweep(workflowId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminResourceApi.RequeueSweep: " + e.Message );
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
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="verifyandrepairworkflowconsistency"></a>
# **VerifyAndRepairWorkflowConsistency**
> string VerifyAndRepairWorkflowConsistency (string workflowId)

Verify and repair workflow consistency

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class VerifyAndRepairWorkflowConsistencyExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new AdminResourceApi();
            var workflowId = workflowId_example;  // string | 

            try
            {
                // Verify and repair workflow consistency
                string result = apiInstance.VerifyAndRepairWorkflowConsistency(workflowId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminResourceApi.VerifyAndRepairWorkflowConsistency: " + e.Message );
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
 - **Accept**: text/plain

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="view"></a>
# **View**
> List<Task> View (string tasktype, int? start = null, int? count = null)

Get the list of pending tasks for a given task type

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ViewExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new AdminResourceApi();
            var tasktype = tasktype_example;  // string | 
            var start = 56;  // int? |  (optional)  (default to 0)
            var count = 56;  // int? |  (optional)  (default to 100)

            try
            {
                // Get the list of pending tasks for a given task type
                List&lt;Task&gt; result = apiInstance.View(tasktype, start, count);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AdminResourceApi.View: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **tasktype** | **string**|  | 
 **start** | **int?**|  | [optional] [default to 0]
 **count** | **int?**|  | [optional] [default to 100]

### Return type

[**List<Task>**](Task.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
