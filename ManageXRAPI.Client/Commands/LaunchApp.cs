using Newtonsoft.Json;

namespace ManageXRAPI.Client.Commands
{
    public class LaunchApp
    {
        [JsonProperty("packageName")]
        public string PackageName { get; set; } = "";
    }
}