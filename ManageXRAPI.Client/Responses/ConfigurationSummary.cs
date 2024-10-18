using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class ConfigurationSummary
    {
        [JsonProperty("id")]
        public string Id { get; set; } = "";
        
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("registrationCode")]
        public string RegistrationCode { get; set; } = "";
        
        [JsonProperty("deviceCount")]
        public int DeviceCount { get; set; }
    }
}