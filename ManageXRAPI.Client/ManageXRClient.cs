using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ManageXRAPI.Client.Auth;
using ManageXRAPI.Client.Commands;
using ManageXRAPI.Client.Requests;
using ManageXRAPI.Client.Responses;
using Newtonsoft.Json;

namespace ManageXRAPI.Client
{
    /// <inheritdoc/>
    public class ManageXRClient : IManageXRClient
    {
        private const string apiAddress = "https://managexrapi.com/";
        private readonly HttpClient client;

        private string OrganisationRoute => $"organizations/{organisationId}";

        private readonly string organisationId;

        /// <summary>
        /// Initialises a new instance of the <see cref="ManageXRClient"/> class.
        /// </summary>
        /// <param name="credentials">The authentication credentials.</param>
        /// <param name="httpClient">The HTTP client.</param>
        public ManageXRClient(AuthCredentials credentials, HttpClient httpClient)
        {
            organisationId = credentials.OrganisationId;

            client = httpClient;
            client.BaseAddress = new Uri(apiAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = CreateAuthHeader(credentials.KeyId, credentials.KeySecret);
        }
        
        /// <inheritdoc />
        public async Task<List<Device>> ListDevices()
        {
            HttpResponseMessage response = await client.GetAsync($"{OrganisationRoute}/devices");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<Device[]>(data);
                return content.ToList();
            }

            throw new HttpRequestException(response.ReasonPhrase);
        }
        
        /// <inheritdoc />
        public async Task<Device> GetDevice(string deviceId)
        {
            HttpResponseMessage response = await client.GetAsync($"{OrganisationRoute}/devices/{deviceId}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<Device>(data);
                return content;
            }

            throw new HttpRequestException(response.ReasonPhrase);
        }

        /// <inheritdoc />
        public async Task EditDevice(string deviceId, EditDeviceOptions options)
        {
            HttpResponseMessage response = await client.PatchAsJsonAsync($"{OrganisationRoute}/devices/{deviceId}", options);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
        }
        
        /// <inheritdoc />
        public async Task SendCommand(string deviceId, DeviceCommand deviceCommand)
        {
            var json = JsonConvert.SerializeObject(deviceCommand);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"{OrganisationRoute}/devices/{deviceId}/command", content);
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new HttpRequestException(response.ReasonPhrase);
        }

        /// <inheritdoc />
        public async Task SendBatchCommand(BatchCommand batchCommand)
        {
            var json = JsonConvert.SerializeObject(batchCommand);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"{OrganisationRoute}/devices/batch-command", content);
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new HttpRequestException(response.ReasonPhrase);
        }

        /// <inheritdoc />
        public async Task SetPauseUpdates(bool pauseUpdates, params string[] deviceIds)
        {
            var json = JsonConvert.SerializeObject(new SetPauseUpdateOptions
            {
                DeviceIds = deviceIds,
                PauseUpdates = pauseUpdates
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"{OrganisationRoute}/devices/set-pause-updates", content);
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new HttpRequestException(response.ReasonPhrase);
        }

        /// <inheritdoc />
        public async Task<List<ConfigurationSummary>> ListConfigurations()
        {
            HttpResponseMessage response = await client.GetAsync($"{OrganisationRoute}/configurations");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<ConfigurationSummary[]>(data);
                return content.ToList();
            }

            throw new HttpRequestException(response.ReasonPhrase);
        }
        
        /// <inheritdoc />
        public async Task<Configuration> GetConfiguration(string configurationId)
        {
            HttpResponseMessage response = await client.GetAsync($"{OrganisationRoute}/configurations/{configurationId}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<Configuration>(data);
                return content;
            }

            throw new HttpRequestException(response.ReasonPhrase);
        }

        /// <summary>
        /// Creates the authentication header.
        /// </summary>
        /// <param name="keyId">The key ID.</param>
        /// <param name="keySecret">The key secret.</param>
        /// <returns>The authentication header value.</returns>
        private AuthenticationHeaderValue CreateAuthHeader(string keyId, string keySecret)
        {
            var bytes = Encoding.UTF8.GetBytes($"{keyId}:{keySecret}");
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));
        }
    }
}