using Newtonsoft.Json;

namespace ManageXRAPI.Client.Requests
{
    public class EditDeviceOptions
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("notes")]
        public string Notes { get; set; }
    
        [JsonProperty("configurationId")]
        public string ConfigurationId { get; set; }
    }
}