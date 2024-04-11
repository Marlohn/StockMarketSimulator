using Azure.Data.Tables;
using AzureTables.Connector;
using AzureTables.Connector.Enums;
using Stocks.Kernel.Models;

namespace Stocks.Kernel.Infrastructure.Repository
{
    public class StockRepository : AzureTablesRepositoryBase, IStockRepository
    {
        public StockRepository(Dictionary<ClientNames, TableServiceClient> tableServiceClients) : base(tableServiceClients, ClientNames.Sinks, "Stocks")
        {
        }

        public async Task<AzureTableStockModel?> Get(string stockSymbol)
        {
            return await GetByExpression<AzureTableStockModel>(x => x.RowKey == stockSymbol);
        }

        public async Task<List<AzureTableStockModel>> GetAll()
        {
            return await GetAll<AzureTableStockModel>();
        }
    }
}