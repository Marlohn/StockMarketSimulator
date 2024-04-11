using Azure.Data.Tables;
using AzureTables.Connector;
using AzureTables.Connector.Enums;
using Wallets.Kernel.Models;

namespace Wallets.Kernel.Infrastructure.Repository
{
    internal class WalletsRepository : AzureTablesRepositoryBase, IWalletsRepository
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