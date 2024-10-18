using Newtonsoft.Json;

namespace ManageXRAPI.Client.Requests
{
    public class SetPauseUpdateOptions
    {
        [JsonProperty("deviceIds")]
        public string[] DeviceIds { get; set; }
        
        [JsonProperty("pauseUpdates")]
        public bool PauseUpdates { get; set; }
    }
}