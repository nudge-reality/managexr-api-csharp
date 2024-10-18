![ManageXR Wordmark](.github/images/wordmark.png)

# ManageXR API C# Wrapper

Welcome to the ManageXR API C# Wrapper! This library provides a simple and convenient way to interact with the ManageXR API using C#.

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Authentication](#authentication)
- [Supported Endpoints](#supported-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Installation

````
Install-Package ManageXRAPI.Client
````

## Authentication

To authenticate with the ManageXR API, you'll need your Organisation Id as well as a Key and Secret. You can obtain this from your ManageXR account settings from the related Organisation.

```csharp
var credentials = new AuthCredentials("your-organisation-id", "your-key-id", "your-key-secret");
```

When using the `ManageXRAPI.Extensions` package, you can utilise the `AddManageXRClient` function to easily create an instance within your `ServiceCollection`. This function retrieves credentials stored in your `appsettings.json`, an example of this can be found below:

````json
// appsettings.json
{
  "ManageXR": {
    "OrganisationId": "",
    "KeyId": "",
    "KeySecret": ""
  }
}
````

## Usage

Here's a quick example to get you started with the ManageXR API C# Wrapper:

```csharp
using System;
using ManageXRCSharpWrapper;

namespace ManageXRExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Store Credentials
            var credentials = new AuthCredentials("your-organisation-id", "your-key-id", "your-key-secret");
            
            // Initialise the API client
            var mxrClient = new ManageXRClient(credentials, new HttpClient());

            // Get device information
            var devices = mxrClient.ListDevices();

            foreach(var device in devices)
            {
              Console.WriteLine($"Device Name: {device.Name}");
              Console.WriteLine($"Device Serial: {device.Serial}");
            }
            
            // Update device settings
            mxrClient.EditDevice("device-id", new EditDeviceOptions
            {
                Name = "Updated Device Name",
                // Add other update options as needed
            });

            Console.WriteLine("Device updated successfully.");
        }
    }
}
```

## Supported Endpoints

The ManageXR API C# Wrapper supports various API calls, including:

- [`ListDevices()`](https://docs.managexr.com/api-reference/endpoint/list-devices): Retrieve a list of all devices

- [`GetDevice(string deviceId)`](https://docs.managexr.com/api-reference/endpoint/get-device): Retrieve a specific device with the matching `deviceId`

  > `deviceId` in this context refers to a headset's Hardware ID
- [`EditDevice(string deviceId, EditDeviceOptions options)`](https://docs.managexr.com/api-reference/endpoint/edit): Edit various settings of a specific device.
- [`SendCommand(string deviceId, DeviceCommand deviceCommand)`](https://docs.managexr.com/api-reference/endpoint/send-command): Trigger a command on a specific device.
- [`SendBatchCommand(BatchCommand batchCommand)`](https://docs.managexr.com/api-reference/endpoint/batch-commands): Trigger a command on a list of headsets
- [`SetPauseUpdates(bool pauseUpdates, params string[] deviceIds)`](https://docs.managexr.com/api-reference/endpoint/set-pause-updates): Enable/Disable Configuration Updates on a set of devices.
- [`ListConfigurations`](https://docs.managexr.com/api-reference/endpoint/list-configurations): List all the configurations associated with the organisation
- [`GetConfiguration(string configurationId)`](https://docs.managexr.com/api-reference/endpoint/get-configuration): Get a specific configuration using the configuration id

Refer to the [official ManageXR API documentation](https://docs.managexr.com/introduction) for detailed information on all available methods.

> For any missing endpoints not implemented in the ManageXR API C# Wrapper, feel free to [make an issue](https://github.com/nudge-reality/managexr-api-csharp/issues) or [submit a Pull Request](#contributing)!

## Contributing

We welcome contributions to the ManageXR API C# Wrapper! If you'd like to contribute, please fork the repository and submit a pull request!

When it comes to testing, add an `appsettings.test.json` file to the `ManageXRAPI.Tests` project and add your credentials in there, as structured [above](#authentication).

> You will need to modify the `TestCase` parameters that reference `<device-id-here>` and `<configuration-id-here>` to values that exist in the organisation you're using to test these functions.

##  License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
