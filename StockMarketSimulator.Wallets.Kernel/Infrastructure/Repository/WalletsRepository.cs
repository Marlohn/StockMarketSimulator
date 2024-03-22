using Azure.Data.Tables;
using AzureTables.Connector;
using AzureTables.Connector.Enuns;

namespace StockMarketSimulator.Wallets.Kernel.Infrastructure.Repository
{
    public class WalletsRepository : AzureTablesRepositoryBase, IWalletsRepository
    {
        public WalletsRepository(Dictionary<string, TableServiceClient> tableServiceClients) : base(tableServiceClients, ClientNames.Wallets, "Wallets")
        {
        }

        public async Task UpsertStock(AzureTableWalletModel azureTableStockModel)
        {
            await AddEditEntity(azureTableStockModel);
        }
    }
}