using Azure;
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

        public async Task<AzureTableWalletModel?> Get(Guid walletId, string stockName)
        {
            return await GetByExpression<AzureTableWalletModel>(x => x.PartitionKey == walletId.ToString() && x.RowKey == stockName);
        }

        public async Task<List<AzureTableWalletModel>> GetAll(Guid walletId)
        {
            return await Query<AzureTableWalletModel>(x => x.PartitionKey == walletId.ToString());
        }
    }
}