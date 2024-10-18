using System.Net.Http;
using ManageXRAPI.Client;
using ManageXRAPI.Client.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManageXRAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddManageXRClient(this IServiceCollection serviceCollection, IConfigurationRoot configuration)
        {
            var credentials = new AuthCredentials();
            configuration.GetSection(AuthCredentials.Section).Bind(credentials);
            serviceCollection.AddScoped<IManageXRClient>(provider =>
            {
                var httpClientFactory = provider.GetService<IHttpClientFactory>();
                var client = httpClientFactory?.CreateClient() ?? new HttpClient();

                return new ManageXRClient(credentials, client);
            });
        }
    }
}