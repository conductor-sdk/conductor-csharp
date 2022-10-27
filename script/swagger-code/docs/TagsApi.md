# IO.Swagger.Api.TagsApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddTaskTag**](TagsApi.md#addtasktag) | **POST** /api/metadata/task/{taskName}/tags | Adds the tag to the task
[**AddWorkflowTag**](TagsApi.md#addworkflowtag) | **POST** /api/metadata/workflow/{name}/tags | Adds the tag to the workflow
[**DeleteTaskTag**](TagsApi.md#deletetasktag) | **DELETE** /api/metadata/task/{taskName}/tags | Removes the tag of the task
[**DeleteWorkflowTag**](TagsApi.md#deleteworkflowtag) | **DELETE** /api/metadata/workflow/{name}/tags | Removes the tag of the workflow
[**GetTags1**](TagsApi.md#gettags1) | **GET** /api/metadata/tags | List all tags
[**GetTaskTags**](TagsApi.md#gettasktags) | **GET** /api/metadata/task/{taskName}/tags | Returns all the tags of the task
[**GetWorkflowTags**](TagsApi.md#getworkflowtags) | **GET** /api/metadata/workflow/{name}/tags | Returns all the tags of the workflow
[**SetTaskTags**](TagsApi.md#settasktags) | **PUT** /api/metadata/task/{taskName}/tags | Adds the tag to the task
[**SetWorkflowTags**](TagsApi.md#setworkflowtags) | **PUT** /api/metadata/workflow/{name}/tags | Set the tags of the workflow

<a name="addtasktag"></a>
# **AddTaskTag**
> Object AddTaskTag (TagObject body, string taskName)

Adds the tag to the task

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddTaskTagExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TagsApi();
            var body = new TagObject(); // TagObject | 
            var taskName = taskName_example;  // string | 

            try
            {
                // Adds the tag to the task
                Object result = apiInstance.AddTaskTag(body, taskName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsApi.AddTaskTag: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**TagObject**](TagObject.md)|  | 
 **taskName** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="addworkflowtag"></a>
# **AddWorkflowTag**
> Object AddWorkflowTag (TagObject body, string name)

Adds the tag to the workflow

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddWorkflowTagExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TagsApi();
            var body = new TagObject(); // TagObject | 
            var name = name_example;  // string | 

            try
            {
                // Adds the tag to the workflow
                Object result = apiInstance.AddWorkflowTag(body, name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsApi.AddWorkflowTag: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**TagObject**](TagObject.md)|  | 
 **name** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="deletetasktag"></a>
# **DeleteTaskTag**
> Object DeleteTaskTag (TagString body, string taskName)

Removes the tag of the task

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteTaskTagExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TagsApi();
            var body = new TagString(); // TagString | 
            var taskName = taskName_example;  // string | 

            try
            {
                // Removes the tag of the task
                Object result = apiInstance.DeleteTaskTag(body, taskName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsApi.DeleteTaskTag: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**TagString**](TagString.md)|  | 
 **taskName** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="deleteworkflowtag"></a>
# **DeleteWorkflowTag**
> Object DeleteWorkflowTag (TagObject body, string name)

Removes the tag of the workflow

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteWorkflowTagExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TagsApi();
            var body = new TagObject(); // TagObject | 
            var name = name_example;  // string | 

            try
            {
                // Removes the tag of the workflow
                Object result = apiInstance.DeleteWorkflowTag(body, name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsApi.DeleteWorkflowTag: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**TagObject**](TagObject.md)|  | 
 **name** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettags1"></a>
# **GetTags1**
> List<TagObject> GetTags1 ()

List all tags

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTags1Example
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TagsApi();

            try
            {
                // List all tags
                List&lt;TagObject&gt; result = apiInstance.GetTags1();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsApi.GetTags1: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<TagObject>**](TagObject.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettasktags"></a>
# **GetTaskTags**
> List<TagObject> GetTaskTags (string taskName)

Returns all the tags of the task

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTaskTagsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TagsApi();
            var taskName = taskName_example;  // string | 

            try
            {
                // Returns all the tags of the task
                List&lt;TagObject&gt; result = apiInstance.GetTaskTags(taskName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsApi.GetTaskTags: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **taskName** | **string**|  | 

### Return type

[**List<TagObject>**](TagObject.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getworkflowtags"></a>
# **GetWorkflowTags**
> List<TagObject> GetWorkflowTags (string name)

Returns all the tags of the workflow

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWorkflowTagsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TagsApi();
            var name = name_example;  // string | 

            try
            {
                // Returns all the tags of the workflow
                List&lt;TagObject&gt; result = apiInstance.GetWorkflowTags(name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsApi.GetWorkflowTags: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 

### Return type

[**List<TagObject>**](TagObject.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="settasktags"></a>
# **SetTaskTags**
> Object SetTaskTags (List<TagObject> body, string taskName)

Adds the tag to the task

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SetTaskTagsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TagsApi();
            var body = new List<TagObject>(); // List<TagObject> | 
            var taskName = taskName_example;  // string | 

            try
            {
                // Adds the tag to the task
                Object result = apiInstance.SetTaskTags(body, taskName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsApi.SetTaskTags: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;TagObject&gt;**](TagObject.md)|  | 
 **taskName** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="setworkflowtags"></a>
# **SetWorkflowTags**
> Object SetWorkflowTags (List<TagObject> body, string name)

Set the tags of the workflow

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class SetWorkflowTagsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TagsApi();
            var body = new List<TagObject>(); // List<TagObject> | 
            var name = name_example;  // string | 

            try
            {
                // Set the tags of the workflow
                Object result = apiInstance.SetWorkflowTags(body, name);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TagsApi.SetWorkflowTags: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;TagObject&gt;**](TagObject.md)|  | 
 **name** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
