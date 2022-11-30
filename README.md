# Netflix Conductor C# SDK

`conductor-csharp` repository provides the client SDKs to build Task Workers in C#

## Quick Start

1. [Setup conductor-csharp package](#Setup-conductor-csharp-package)
2. [Create and run Task Workers](/docs/readme/workers.md)
3. [Create workflows using Code](/docs/readme/workflow.md)
4. [API Documentation](/docs/api/)
   
### Setup conductor-csharp package

```csharp
// TODO
```

## Configuration

### Authentication settings (optional)
Use if your conductor server requires authentication
* keyId: Key
* keySecret: Secret for the Key

```csharp
// TODO
authenticationSettings := settings.NewAuthenticationSettings(
  "keyId",
  "keySecret",
)
```

### Access Control Setup
See [Access Control](https://orkes.io/content/docs/getting-started/concepts/access-control) for more details on role based access control with Conductor and generating API keys for your environment.

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
// SDK uses [logrus](https://github.com/sirupsen/logrus) for the logging.
func init() {
	log.SetFormatter(&log.TextFormatter{})
	log.SetOutput(os.Stdout)
	log.SetLevel(log.DebugLevel)
}
```

### Next: [Create and run Task Workers](/docs/readme/workers.md)
