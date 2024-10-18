using ManageXRAPI.Client;
using ManageXRAPI.Client.Auth;
using ManageXRAPI.Client.Commands;
using ManageXRAPI.Client.Enums;
using ManageXRAPI.Client.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace ManageXRAPI.Tests;

public class ClientTests
{
    private ManageXRClient sut;
    private AuthCredentials credentials;
    private HttpClient client;
    private IHttpClientFactory clientFactory;

    private ServiceProvider serviceProvider;

    public ClientTests()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json")
            .AddEnvironmentVariables()
            .Build();

        credentials = new AuthCredentials();
        configuration.GetSection(AuthCredentials.Section).Bind(credentials);
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddHttpClient();
        serviceProvider = serviceCollection.BuildServiceProvider();
        clientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    }

    [SetUp]
    public void SetUp()
    {
        client = clientFactory.CreateClient();
        sut = new ManageXRClient(credentials, client);
    }

    [TearDown]
    public void TearDown()
    {
        serviceProvider.Dispose();
    }

    [Test, Category("Integration")]
    public Task ListDevices_WhenCalledWithValidConfiguration_DoesNotThrow()
    {
        AsyncTestDelegate td = async () => await sut.ListDevices();

        Assert.DoesNotThrowAsync(td);

        return Task.CompletedTask;
    }

    [Test, Category("Integration")]
    public Task GetDevice_WhenCalledWithValidConfiguration_DoesNotThrow()
    {
        AsyncTestDelegate td = async () => await sut.GetDevice("<device-id-here>");

        Assert.DoesNotThrowAsync(td);

        return Task.CompletedTask;
    }

    [TestCase("<device-id-here>"), Category("Integration")]
    public async Task EditDevice_WhenCalledWithValidDeviceId_DoesNotThrow(string deviceId)
    {
        AsyncTestDelegate td = async () => await sut.EditDevice(deviceId, new EditDeviceOptions
        {
            Name = "<name-here>"
        });

        Assert.DoesNotThrowAsync(td);
    }

    [TestCase("<device-id-here>"), Category("Integration")]
    public Task SendCommand_WhenCalledWithValidParams_DoesNotThrow(string deviceId)
    {
        AsyncTestDelegate td = async () => await sut.SendCommand(deviceId, new DeviceCommand
        {
            Action = CommandAction.Sync
        });

        Assert.DoesNotThrowAsync(td);
        return Task.CompletedTask;
    }

    [Test, Category("Integration")]
    public Task SendBatchCommand_WhenCalledWithValidParams_DoesNotThrow()
    {
        AsyncTestDelegate td = async () => await sut.SendBatchCommand(new BatchCommand
        {
            DeviceIds = ["<device-id-here>", "<device-id-here>", "<device-id-here>"],
            Action = CommandAction.Sync
        });

        Assert.DoesNotThrowAsync(td);
        return Task.CompletedTask;
    }

    [TestCase("<device-id-here>"), Category("Integration")]
    public void SetPauseUpdates_WhenCalledWithValidDeviceId_DoesNotThrow(string deviceId)
    {
        AsyncTestDelegate td = async () => await sut.SetPauseUpdates(false, deviceId);

        Assert.DoesNotThrowAsync(td);
    }

    [Test, Category("Integration")]
    public void ListConfigurations_WhenCalled_DoesNotThrow()
    {
        AsyncTestDelegate td = async () => await sut.ListConfigurations();

        Assert.DoesNotThrowAsync(td);
    }
    
    [TestCase("<configuration-id-here>"), Category("Integration")]
    public void GetConfiguration_WhenCalledWithValidConfigurationId_DoesNotThrow(string configurationId)
    {
        AsyncTestDelegate td = async () => await sut.GetConfiguration(configurationId);

        Assert.DoesNotThrowAsync(td);
    }
}