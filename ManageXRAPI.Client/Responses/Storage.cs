using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class Storage
    {
        [JsonProperty("available")]
        public long Available { get; set; }
    }
}