using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class Organisation
    {
        [JsonProperty("id")]
        public string Id { get; set; } = "";
        
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("activeDevices")]
        public string RegistrationCode { get; set; } = "";
        
        [JsonProperty("deviceLicenses")]
        public int DeviceCount { get; set; }
    }
}