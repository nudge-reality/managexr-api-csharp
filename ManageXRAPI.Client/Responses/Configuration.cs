using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class Configuration : ConfigurationSummary
    {
        [JsonProperty("deviceExperience")]
        public string DeviceExperience { get; set; }

        [JsonProperty("apps")]
        public List<App> Apps { get; set; }

        [JsonProperty("videos")]
        public List<Video> Videos { get; set; }

        [JsonProperty("webxrLinks")]
        public List<WebXRLink> WebXRLinks { get; set; }

        [JsonProperty("files")]
        public List<File> Files { get; set; }

        [JsonProperty("wifiNetworks")]
        public List<WifiNetwork> WifiNetworks { get; set; }

        [JsonProperty("kioskAppId")]
        public string KioskAppId { get; set; }
    }
}