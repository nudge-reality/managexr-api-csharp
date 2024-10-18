using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManageXRAPI.Client.Responses
{
    public class App
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("packageName")]
        public string PackageName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("versionCode")]
        public int VersionCode { get; set; }

        [JsonProperty("versionName")]
        public string VersionName { get; set; }

        [JsonProperty("versionLabel")]
        public string VersionLabel { get; set; }

        [JsonProperty("apkSize")]
        public int ApkSize { get; set; }

        [JsonProperty("obbSize")]
        public int ObbSize { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("forceInstall")]
        public bool ForceInstall { get; set; }

        [JsonProperty("autoGrantPermissions")]
        public bool AutoGrantPermissions { get; set; }

        [JsonProperty("expirationTimestamp")]
        public long ExpirationTimestamp { get; set; }

        [JsonProperty("expirationBehavior")]
        public string ExpirationBehavior { get; set; }
    }
}