using Azure.Data.Tables;
using AzureTables.Connector.Models;
using Microsoft.Extensions.DependencyInjection;

namespace AzureTables.Connector.IoC
{
    public static class ServiceCollectionExtensionMethods
    {
        public static void AddAzureTables(this IServiceCollection services, Action<AzureTablesOptions> options)
        {
            var config = new AzureTablesOptions();
            options(config);

            var tableServiceClients = new Dictionary<string, TableServiceClient>
            {
                { "Users", new TableServiceClient(config.UsersConnectionString) },
                { "Sinks", new TableServiceClient(config.SinksConnectionString) }
            };

            services.AddSingleton(tableServiceClients);
        }

        public static void AddAzureTables(this IServiceCollection services)
        {
            var tableServiceClients = new Dictionary<string, TableServiceClient>
            {
                //Todo: use enum or const
                { "Sinks", new TableServiceClient("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;") }
            };

            services.AddSingleton(tableServiceClients);
        }

    }
}
