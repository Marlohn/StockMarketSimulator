using Azure.Data.Tables;
using AzureTables.Connector;
using AzureTables.Connector.Enuns;
using StockMarketSimulator.Wallets.Kernel.Models;

namespace StockMarketSimulator.Wallets.Kernel.Infrastructure.Repository
{
    public class WalletsRepository : AzureTablesRepositoryBase, IWalletsRepository
    {
        public WalletsRepository(Dictionary<ClientNames, TableServiceClient> tableServiceClients) : base(tableServiceClients, ClientNames.Wallets, "Wallets")
        {
        }

        public async Task Upsert(AzureTableWalletModel azureTableWalletModel)
        {
            await AddEditEntity(azureTableWalletModel);
        }
    }
}