using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class Video
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("videoType")]
        public string VideoType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
    }
}