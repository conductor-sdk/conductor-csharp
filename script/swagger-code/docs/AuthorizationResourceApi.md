# IO.Swagger.Api.AuthorizationResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetPermissions**](AuthorizationResourceApi.md#getpermissions) | **GET** /api/auth/authorization/{type}/{id} | Get the access that have been granted over the given object
[**GrantPermissions**](AuthorizationResourceApi.md#grantpermissions) | **POST** /api/auth/authorization | Grant access to a user over the target
[**RemovePermissions**](AuthorizationResourceApi.md#removepermissions) | **DELETE** /api/auth/authorization | Remove user&#x27;s access over the target

<a name="getpermissions"></a>
# **GetPermissions**
> Object GetPermissions (string type, string id)

Get the access that have been granted over the given object

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetPermissionsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new AuthorizationResourceApi();
            var type = type_example;  // string | 
            var id = id_example;  // string | 

            try
            {
                // Get the access that have been granted over the given object
                Object result = apiInstance.GetPermissions(type, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthorizationResourceApi.GetPermissions: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **type** | **string**|  | 
 **id** | **string**|  | 

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="grantpermissions"></a>
# **GrantPermissions**
> Response GrantPermissions (AuthorizationRequest body)

Grant access to a user over the target

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GrantPermissionsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new AuthorizationResourceApi();
            var body = new AuthorizationRequest(); // AuthorizationRequest | 

            try
            {
                // Grant access to a user over the target
                Response result = apiInstance.GrantPermissions(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthorizationResourceApi.GrantPermissions: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**AuthorizationRequest**](AuthorizationRequest.md)|  | 

### Return type

[**Response**](Response.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="removepermissions"></a>
# **RemovePermissions**
> Response RemovePermissions (AuthorizationRequest body)

Remove user's access over the target

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class RemovePermissionsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new AuthorizationResourceApi();
            var body = new AuthorizationRequest(); // AuthorizationRequest | 

            try
            {
                // Remove user's access over the target
                Response result = apiInstance.RemovePermissions(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AuthorizationResourceApi.RemovePermissions: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**AuthorizationRequest**](AuthorizationRequest.md)|  | 

### Return type

[**Response**](Response.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
