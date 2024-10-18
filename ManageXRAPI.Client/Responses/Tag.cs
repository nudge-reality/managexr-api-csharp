using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class Tag
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}