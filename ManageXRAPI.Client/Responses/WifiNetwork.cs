using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class WifiNetwork
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ssid")]
        public string Ssid { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}