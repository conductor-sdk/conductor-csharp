# IO.Swagger.Api.ApplicationResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddRoleToApplicationUser**](ApplicationResourceApi.md#addroletoapplicationuser) | **POST** /api/applications/{applicationId}/roles/{role} | 
[**CreateAccessKey**](ApplicationResourceApi.md#createaccesskey) | **POST** /api/applications/{id}/accessKeys | Create an access key for an application
[**CreateApplication**](ApplicationResourceApi.md#createapplication) | **POST** /api/applications | Create an application
[**DeleteAccessKey**](ApplicationResourceApi.md#deleteaccesskey) | **DELETE** /api/applications/{applicationId}/accessKeys/{keyId} | Delete an access key
[**DeleteApplication**](ApplicationResourceApi.md#deleteapplication) | **DELETE** /api/applications/{id} | Delete an application
[**DeleteTagForApplication**](ApplicationResourceApi.md#deletetagforapplication) | **DELETE** /api/applications/{id}/tags | Delete a tag for application
[**GetAccessKeys**](ApplicationResourceApi.md#getaccesskeys) | **GET** /api/applications/{id}/accessKeys | Get application&#x27;s access keys
[**GetApplication**](ApplicationResourceApi.md#getapplication) | **GET** /api/applications/{id} | Get an application by id
[**GetTagsForApplication**](ApplicationResourceApi.md#gettagsforapplication) | **GET** /api/applications/{id}/tags | Get tags by application
[**ListApplications**](ApplicationResourceApi.md#listapplications) | **GET** /api/applications | Get all applications
[**PutTagForApplication**](ApplicationResourceApi.md#puttagforapplication) | **PUT** /api/applications/{id}/tags | Put a tag to application
[**RemoveRoleFromApplicationUser**](ApplicationResourceApi.md#removerolefromapplicationuser) | **DELETE** /api/applications/{applicationId}/roles/{role} | 
[**ToggleAccessKeyStatus**](ApplicationResourceApi.md#toggleaccesskeystatus) | **POST** /api/applications/{applicationId}/accessKeys/{keyId}/status | Toggle the status of an access key
[**UpdateApplication**](ApplicationResourceApi.md#updateapplication) | **PUT** /api/applications/{id} | Update an application

<a name="addroletoapplicationuser"></a>
# **AddRoleToApplicationUser**
> Object AddRoleToApplicationUser (string applicationId, string role)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class AddRoleToApplicationUserExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var applicationId = applicationId_example;  // string | 
            var role = role_example;  // string | 

            try
            {
                Object result = apiInstance.AddRoleToApplicationUser(applicationId, role);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.AddRoleToApplicationUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationId** | **string**|  | 
 **role** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="createaccesskey"></a>
# **CreateAccessKey**
> Object CreateAccessKey (string id)

Create an access key for an application

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateAccessKeyExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var id = id_example;  // string | 

            try
            {
                // Create an access key for an application
                Object result = apiInstance.CreateAccessKey(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.CreateAccessKey: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="createapplication"></a>
# **CreateApplication**
> Object CreateApplication (CreateOrUpdateApplicationRequest body)

Create an application

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateApplicationExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var body = new CreateOrUpdateApplicationRequest(); // CreateOrUpdateApplicationRequest | 

            try
            {
                // Create an application
                Object result = apiInstance.CreateApplication(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.CreateApplication: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**CreateOrUpdateApplicationRequest**](CreateOrUpdateApplicationRequest.md)|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="deleteaccesskey"></a>
# **DeleteAccessKey**
> Object DeleteAccessKey (string applicationId, string keyId)

Delete an access key

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteAccessKeyExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var applicationId = applicationId_example;  // string | 
            var keyId = keyId_example;  // string | 

            try
            {
                // Delete an access key
                Object result = apiInstance.DeleteAccessKey(applicationId, keyId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.DeleteAccessKey: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationId** | **string**|  | 
 **keyId** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="deleteapplication"></a>
# **DeleteApplication**
> Object DeleteApplication (string id)

Delete an application

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteApplicationExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var id = id_example;  // string | 

            try
            {
                // Delete an application
                Object result = apiInstance.DeleteApplication(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.DeleteApplication: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="deletetagforapplication"></a>
# **DeleteTagForApplication**
> void DeleteTagForApplication (string id, string body = null)

Delete a tag for application

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class DeleteTagForApplicationExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var id = id_example;  // string | 
            var body = new string(); // string |  (optional) 

            try
            {
                // Delete a tag for application
                apiInstance.DeleteTagForApplication(id, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.DeleteTagForApplication: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **body** | [**string**](string.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getaccesskeys"></a>
# **GetAccessKeys**
> Object GetAccessKeys (string id)

Get application's access keys

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAccessKeysExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var id = id_example;  // string | 

            try
            {
                // Get application's access keys
                Object result = apiInstance.GetAccessKeys(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.GetAccessKeys: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getapplication"></a>
# **GetApplication**
> Object GetApplication (string id)

Get an application by id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetApplicationExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var id = id_example;  // string | 

            try
            {
                // Get an application by id
                Object result = apiInstance.GetApplication(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.GetApplication: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="gettagsforapplication"></a>
# **GetTagsForApplication**
> List<TagObject> GetTagsForApplication (string id)

Get tags by application

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTagsForApplicationExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var id = id_example;  // string | 

            try
            {
                // Get tags by application
                List&lt;TagObject&gt; result = apiInstance.GetTagsForApplication(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.GetTagsForApplication: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

[**List<TagObject>**](TagObject.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="listapplications"></a>
# **ListApplications**
> List<ConductorApplication> ListApplications ()

Get all applications

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ListApplicationsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();

            try
            {
                // Get all applications
                List&lt;ConductorApplication&gt; result = apiInstance.ListApplications();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.ListApplications: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<ConductorApplication>**](ConductorApplication.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="puttagforapplication"></a>
# **PutTagForApplication**
> void PutTagForApplication (string id, string body = null)

Put a tag to application

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PutTagForApplicationExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var id = id_example;  // string | 
            var body = new string(); // string |  (optional) 

            try
            {
                // Put a tag to application
                apiInstance.PutTagForApplication(id, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.PutTagForApplication: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **body** | [**string**](string.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="removerolefromapplicationuser"></a>
# **RemoveRoleFromApplicationUser**
> Object RemoveRoleFromApplicationUser (string applicationId, string role)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RemoveRoleFromApplicationUserExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var applicationId = applicationId_example;  // string | 
            var role = role_example;  // string | 

            try
            {
                Object result = apiInstance.RemoveRoleFromApplicationUser(applicationId, role);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.RemoveRoleFromApplicationUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationId** | **string**|  | 
 **role** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="toggleaccesskeystatus"></a>
# **ToggleAccessKeyStatus**
> Object ToggleAccessKeyStatus (string applicationId, string keyId)

Toggle the status of an access key

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToggleAccessKeyStatusExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var applicationId = applicationId_example;  // string | 
            var keyId = keyId_example;  // string | 

            try
            {
                // Toggle the status of an access key
                Object result = apiInstance.ToggleAccessKeyStatus(applicationId, keyId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.ToggleAccessKeyStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **applicationId** | **string**|  | 
 **keyId** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="updateapplication"></a>
# **UpdateApplication**
> Object UpdateApplication (CreateOrUpdateApplicationRequest body, string id)

Update an application

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateApplicationExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new ApplicationResourceApi();
            var body = new CreateOrUpdateApplicationRequest(); // CreateOrUpdateApplicationRequest | 
            var id = id_example;  // string | 

            try
            {
                // Update an application
                Object result = apiInstance.UpdateApplication(body, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ApplicationResourceApi.UpdateApplication: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**CreateOrUpdateApplicationRequest**](CreateOrUpdateApplicationRequest.md)|  | 
 **id** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
