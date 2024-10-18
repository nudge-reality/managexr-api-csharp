using System.Text.Json.Serialization;

namespace ManageXRAPI.Client.Responses
{
    public class Location
    {
        [JsonPropertyName("city")]
        public string City { get; set; } = "";

        [JsonPropertyName("region")]
        public string Region { get; set; } = "";
    
        [JsonPropertyName("country")]
        public string Country { get; set; } = "";
    
        [JsonPropertyName("continent")]
        public string Continent { get; set; } = "";
    
        [JsonPropertyName("timeZone")]
        public string TimeZone { get; set; } = "";
    }
}