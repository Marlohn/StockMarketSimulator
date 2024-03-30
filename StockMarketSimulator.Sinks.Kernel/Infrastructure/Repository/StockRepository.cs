//using Azure.Data.Tables;
//using AzureTables.Connector;
//using AzureTables.Connector.Enuns;
//using StockMarketSimulator.Sinks.Kernel.Models;

//namespace StockMarketSimulator.Sinks.Kernel.Infrastructure.Repository
//{
//    public class StockRepository : AzureTablesRepositoryBase, IStockRepository
//    {
//        public StockRepository(Dictionary<ClientNames, TableServiceClient> tableServiceClients) : base(tableServiceClients, ClientNames.Sinks, "Stocks")
//        {
//        }

//        public async Task Upsert(AzureTableStockModel azureTableStockModel)
//        {
//            await AddEditEntity(azureTableStockModel);
//        }

//        //public async Task<string> GetUserProfileByEmail(string email, CancellationToken cancellationToken)
//        //{
//        //    //return await GetByExpression<string>(ent => ent.EmailAddress.Equals(email), cancellationToken);
//        //    return string.Empty;
//        //}
//    }
//}


