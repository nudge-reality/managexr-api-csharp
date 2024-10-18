using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class WebXRLink
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }
    }
}