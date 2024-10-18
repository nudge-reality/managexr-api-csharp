using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class Device
    {
        [JsonProperty("serial")]
        public string Serial { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mac")]
        public string Mac { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("batteryLevel")]
        public int BatteryLevel { get; set; }

        [JsonProperty("batteryIsCharging")]
        public bool BatteryIsCharging { get; set; }

        [JsonProperty("online")]
        public bool Online { get; set; }

        [JsonProperty("osVersion")]
        public int OsVersion { get; set; }

        [JsonProperty("outOfDate")]
        public bool OutOfDate { get; set; }

        [JsonProperty("pauseUpdates")]
        public bool PauseUpdates { get; set; }

        [JsonProperty("registerDate")]
        public DateTime RegisterDate { get; set; }

        [JsonProperty("updating")]
        public bool Updating { get; set; }

        [JsonProperty("factoryResetStatus")]
        public string FactoryResetStatus { get; set; }

        [JsonProperty("firmwareVersion")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("configuration")]
        public ConfigurationSummary Configuration { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("tutorialModeEnabled")]
        public bool TutorialModeEnabled { get; set; }

        [JsonProperty("kioskModeOverride")]
        public bool KioskModeOverride { get; set; }

        [JsonProperty("lastSync")]
        public DateTime LastSync { get; set; }

        [JsonProperty("ram")]
        public Ram Ram { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("connectedWifiNetwork")]
        public WifiNetwork ConnectedWifiNetwork { get; set; }

        [JsonProperty("storage")]
        public Storage Storage { get; set; }
    }
}