using ManageXRAPI.Client.Builders;
using ManageXRAPI.Client.Responses;

namespace ManageXRAPI.Tests.Builders;

public class DeviceBuilder : ABuilder<Device>
{
    protected Device? Data { get; set; }

    public DeviceBuilder WithName(string name)
    {
        data.Name = name;
        return this;
    }

    public DeviceBuilder WithSerial(string serial)
    {
        data.Serial = serial;
        return this;
    }

    public DeviceBuilder WithMac(string mac)
    {
        data.Mac = mac;
        return this;
    }

    public DeviceBuilder WithManufacturer(string manufacturer)
    {
        data.Manufacturer = manufacturer;
        return this;
    }

    public DeviceBuilder WithModel(string model)
    {
        data.Model = model;
        return this;
    }

    public DeviceBuilder WithBatteryLevel(int batteryLevel)
    {
        data.BatteryLevel = batteryLevel;
        return this;
    }

    public DeviceBuilder IsOnline(bool isOnline)
    {
        data.Online = isOnline;
        return this;
    }

    public DeviceBuilder WithOsVersion(int osVersion)
    {
        data.OsVersion = osVersion;
        return this;
    }

    public DeviceBuilder OutOfDate(bool outOfDate)
    {
        data.OutOfDate = outOfDate;
        return this;
    }

    public DeviceBuilder WithRegisterDate(DateTime registerDate)
    {
        data.RegisterDate = registerDate;
        return this;
    }

    public DeviceBuilder IsUpdating(bool isUpdating)
    {
        data.Updating = isUpdating;
        return this;
    }

    public DeviceBuilder WithFirmwareVersion(string firmwareVersion)
    {
        data.FirmwareVersion = firmwareVersion;
        return this;
    }

    public DeviceBuilder WithConfiguration(ConfigurationSummary configuration)
    {
        data.Configuration = configuration;
        return this;
    }

    public DeviceBuilder IsTutorialModeEnabled(bool isTutorialModeEnabled)
    {
        data.TutorialModeEnabled = isTutorialModeEnabled;
        return this;
    }

    public DeviceBuilder IsKioskModeOverride(bool isKioskModeOverride)
    {
        data.KioskModeOverride = isKioskModeOverride;
        return this;
    }

    public DeviceBuilder WithLastSync(DateTime lastSync)
    {
        data.LastSync = lastSync;
        return this;
    }
    
    public override Device Build()
    {
        var device = new Device
        {
            Name = data.Name,
            Serial = data.Serial,
            Mac = data.Mac,
            Manufacturer = data.Manufacturer,
            Model = data.Model,
            BatteryLevel = data.BatteryLevel,
            Online = data.Online,
            OsVersion = data.OsVersion,
            OutOfDate = data.OutOfDate,
            RegisterDate = data.RegisterDate,
            Updating = data.Updating,
            FirmwareVersion = data.FirmwareVersion,
            Configuration = data.Configuration,
            TutorialModeEnabled = data.TutorialModeEnabled,
            KioskModeOverride = data.KioskModeOverride,
            LastSync = data.LastSync,
            Location = data.Location,
            Notes = data.Notes,
            Ram = data.Ram,
            Storage = data.Storage,
            Tags = data.Tags,
            PauseUpdates = data.PauseUpdates,
            BatteryIsCharging = data.BatteryIsCharging,
            ConnectedWifiNetwork = data.ConnectedWifiNetwork,
            FactoryResetStatus = data.FactoryResetStatus
        };
        
        Reset();
        
        return device;
    }
}
