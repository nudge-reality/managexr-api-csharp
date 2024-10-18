using ManageXRAPI.Client.Converters;
using ManageXRAPI.Client.Enums;
using Newtonsoft.Json;

namespace ManageXRAPI.Client.Commands
{
    public class DeviceCommand
    {
        [JsonProperty("action"), JsonConverter(typeof(MacroCaseEnumConverter))]
        public CommandAction Action { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; } = new object();
    }
}
