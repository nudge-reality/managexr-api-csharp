using Newtonsoft.Json;

namespace ManageXRAPI.Client.Commands
{
    public class BatchCommand: DeviceCommand
    {
        [JsonProperty("deviceIds")]
        public string[] DeviceIds { get; set; }
    }
}
