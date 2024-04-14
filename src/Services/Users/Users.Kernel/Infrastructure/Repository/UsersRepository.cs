using Azure.Data.Tables;
using AzureTables.Connector;
using AzureTables.Connector.Enums;
using Users.Kernel.Application.Models;
using Users.Kernel.Domain.Repository;

namespace Users.Kernel.Infrastructure.Repository
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
