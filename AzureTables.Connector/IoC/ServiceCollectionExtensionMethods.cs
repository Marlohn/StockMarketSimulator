using Azure.Data.Tables;
using AzureTables.Connector.Enuns;
using Microsoft.Extensions.DependencyInjection;
using StockMarketSimulator.Common.Extensions;

namespace AzureTables.Connector.IoC
{
    public static class ServiceCollectionExtensionMethods
    {
        //public static void AddAzureTables(this IServiceCollection services, Action<AzureTablesOptions> options)
        //{
        //    var config = new AzureTablesOptions();
        //    options(config);



        //    var tableServiceClients = new Dictionary<string, TableServiceClient>
        //    {
        //        { "Users", new TableServiceClient(config.UsersConnectionString) },
        //        { "Sinks", new TableServiceClient(config.SinksConnectionString) },
        //        { "Wallets", new TableServiceClient(config.WalletsConnectionString) }
        //    };

        //    services.AddSingleton(tableServiceClients);
        //}

        public static void AddAzureTables(this IServiceCollection services)
        {
            //Here we have a sample of how to manage different clients and connection strings:

            var tableServiceClients = new Dictionary<ClientNames, TableServiceClient>
            {
                { ClientNames.Sinks, new TableServiceClient("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;") },
                { ClientNames.Wallets, new TableServiceClient("AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;") }
            };

            services.AddSingleton(tableServiceClients);
        }
    }
}