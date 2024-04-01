using Azure.Data.Tables;
using AzureTables.Connector;
using AzureTables.Connector.Enums;
using StockMarketSimulator.Users.Kernel.Models;

namespace StockMarketSimulator.Users.Kernel.Infratructure.Repository
{
    internal class UsersRepository : AzureTablesRepositoryBase, IUsersRepository
    {
        public UsersRepository(Dictionary<ClientNames, TableServiceClient> tableServiceClients) : base(tableServiceClients, ClientNames.Sinks, "Users")
        {
        }

        public async Task Create(AzureTableUserModel azureTableUserModel)
        {
            await AddEntity(azureTableUserModel);
        }

        public async Task<AzureTableUserModel?> Get(string userName)
        {
            return await GetByExpression<AzureTableUserModel>(x => x.RowKey == userName);
        }
    }
}
