using Azure.Data.Tables;
using AzureTables.Connector;
using AzureTables.Connector.Enuns;
using StockMarketSimulator.Users.Kernel.Models;

namespace StockMarketSimulator.Users.Kernel.Infratructure.Repository
{
    public class UsersRepository : AzureTablesRepositoryBase, IUsersRepository
    {
        public UsersRepository(Dictionary<ClientNames, TableServiceClient> tableServiceClients) : base(tableServiceClients, ClientNames.Users, "Users")
        {
        }

        public async Task Create(AzureTableUserModel azureTableUserModel)
        {
            //await AddEditEntity(azureTableUserModel);
            await AddEntity(azureTableUserModel);
        }

        public async Task<AzureTableUserModel?> Get(string userName)
        {
            //await AddEditEntity(azureTableUserModel);
            return await GetByExpression<AzureTableUserModel>(x => x.RowKey == userName);
        }
    }
}
