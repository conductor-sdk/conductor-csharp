# IO.Swagger.Api.TokenResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GenerateToken**](TokenResourceApi.md#generatetoken) | **POST** /api/token | Generate JWT with the given access key
[**GetUserInfo**](TokenResourceApi.md#getuserinfo) | **GET** /api/token/userInfo | Get the user info from the token

<a name="generatetoken"></a>
# **GenerateToken**
> Response GenerateToken (GenerateTokenRequest body)

Generate JWT with the given access key

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GenerateTokenExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TokenResourceApi();
            var body = new GenerateTokenRequest(); // GenerateTokenRequest | 

            try
            {
                // Generate JWT with the given access key
                Response result = apiInstance.GenerateToken(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TokenResourceApi.GenerateToken: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**GenerateTokenRequest**](GenerateTokenRequest.md)|  | 

### Return type

[**Response**](Response.md)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="getuserinfo"></a>
# **GetUserInfo**
> Object GetUserInfo (bool? claims = null)

Get the user info from the token

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetUserInfoExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new TokenResourceApi();
            var claims = true;  // bool? |  (optional)  (default to false)

            try
            {
                // Get the user info from the token
                Object result = apiInstance.GetUserInfo(claims);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TokenResourceApi.GetUserInfo: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **claims** | **bool?**|  | [optional] [default to false]

### Return type

**Object**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
