# Netflix Conductor C# SDK

`conductor-C#` repository provides the client SDKs to build Task Workers in C#

## Quick Start

1. [Setup conductor-C# package](#Setup-conductor-C#-package)
2. [Create and run Task Workers](workers_sdk.md)
3. [Create workflows using Code](workflow_sdk.md)
4. [API Documentation](docs/)
   
### Setup conductor C# package

<!-- TODO -->

## Configuration

### Authentication settings (optional)
Use if your conductor server requires authentication
* keyId: Key
* keySecret: Secret for the Key

```C#
// TODO
authenticationSettings := settings.NewAuthenticationSettings(
  "keyId",
  "keySecret",
)
```

### Access Control Setup
See [Access Control](https://orkes.io/content/docs/getting-started/concepts/access-control) for more details on role based access control with Conductor and generating API keys for your environment.

### Configure API Client
```C#
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

```C#
// TODO
// SDK uses [logrus](https://github.com/sirupsen/logrus) for the logging.
func init() {
	log.SetFormatter(&log.TextFormatter{})
	log.SetOutput(os.Stdout)
	log.SetLevel(log.DebugLevel)
}
```

### Next: [Create and run Task Workers](workers_sdk.md)
