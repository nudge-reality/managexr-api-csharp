using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class File
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }
    }
}