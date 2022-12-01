# Netflix Conductor C# SDK

The `conductor-csharp` repository provides the client SDKs to build task workers in Go.

Building the task workers in C# mainly consists of the following steps:

1. Setup conductor-csharp package
2. Create and run task workers
3. Create workflows using code
   
### Setup Conductor C# Package​

* Create a folder to build your package
```csharp
// TODO
```

## Configurations

### Authentication Settings (Optional)
Configure the authentication settings if your Conductor server requires authentication.
* keyId: Key for authentication.
* keySecret: Secret for the key.

```csharp
// TODO
authenticationSettings := settings.NewAuthenticationSettings(
  "keyId",
  "keySecret",
)
```

### Access Control Setup
See [Access Control](https://orkes.io/content/docs/getting-started/concepts/access-control) for more details on role-based access control with Conductor and generating API keys for your environment.

### Configure API Client
```csharp
// TODO
apiClient := client.NewAPIClient(
    settings.NewAuthenticationSettings(
        KEY,
        SECRET,
    ),
    settings.NewHttpSettings(
        "https://play.orkes.io",
    ),
)
```

### Setup Logging

```csharp
// TODO
// SDK uses [logrus](https://github.com/sirupsen/logrus) for logging.
func init() {
	log.SetFormatter(&log.TextFormatter{})
	log.SetOutput(os.Stdout)
	log.SetLevel(log.DebugLevel)
}
```

### Next: [Create and run task workers](/docs/readme/workers.md)
