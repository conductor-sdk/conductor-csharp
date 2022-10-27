# IO.Swagger.Api.MigrationResourceApi

All URIs are relative to *https://pg-staging.orkesconductor.com/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**MigrateIndex**](MigrationResourceApi.md#migrateindex) | **GET** /api/admin/migrate_index | Migrate Workflow Index t o the sharded table
[**MigrateMetadata**](MigrationResourceApi.md#migratemetadata) | **GET** /api/admin/migrate_metadata | Migrate Workflow and Task Definitions to Postgres
[**MigrateWorkflows**](MigrationResourceApi.md#migrateworkflows) | **GET** /api/admin/migrate_workflow | Migrate workflows from Redis to Postgres

<a name="migrateindex"></a>
# **MigrateIndex**
> int? MigrateIndex ()

Migrate Workflow Index t o the sharded table

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MigrateIndexExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MigrationResourceApi();

            try
            {
                // Migrate Workflow Index t o the sharded table
                int? result = apiInstance.MigrateIndex();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MigrationResourceApi.MigrateIndex: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**int?**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="migratemetadata"></a>
# **MigrateMetadata**
> void MigrateMetadata ()

Migrate Workflow and Task Definitions to Postgres

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MigrateMetadataExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MigrationResourceApi();

            try
            {
                // Migrate Workflow and Task Definitions to Postgres
                apiInstance.MigrateMetadata();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MigrationResourceApi.MigrateMetadata: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
<a name="migrateworkflows"></a>
# **MigrateWorkflows**
> Dictionary<string, Object> MigrateWorkflows (int? batchSize, long? startFromTimestamp)

Migrate workflows from Redis to Postgres

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class MigrateWorkflowsExample
    {
        public void main()
        {
            // Configure API key authorization: api_key
            Configuration.Default.AddApiKey("X-Authorization", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("X-Authorization", "Bearer");

            var apiInstance = new MigrationResourceApi();
            var batchSize = 56;  // int? | 
            var startFromTimestamp = 789;  // long? | 

            try
            {
                // Migrate workflows from Redis to Postgres
                Dictionary&lt;string, Object&gt; result = apiInstance.MigrateWorkflows(batchSize, startFromTimestamp);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MigrationResourceApi.MigrateWorkflows: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **batchSize** | **int?**|  | 
 **startFromTimestamp** | **long?**|  | 

### Return type

**Dictionary<string, Object>**

### Authorization

[api_key](../README.md#api_key)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: */*

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)
