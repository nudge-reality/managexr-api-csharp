using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class Ram
    {
        [JsonProperty("available")]
        public long Available { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}