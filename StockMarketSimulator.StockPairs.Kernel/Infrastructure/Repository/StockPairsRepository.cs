using Azure.Data.Tables;
using AzureTables.Connector;
using AzureTables.Connector.Enums;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.StockPairs.Kernel.Infrastructure.Repository
{
    internal class StockPairsRepository : AzureTablesRepositoryBase, IStockPairsRepository
    {
        //Todo: Generate a const for stockPairs
        public StockPairsRepository(Dictionary<ClientNames, TableServiceClient> tableServiceClients) : base(tableServiceClients, ClientNames.Sinks, "StockPairs")
        {
        }

        public async Task<AzureTableStockPairModel?> Get(string baseSymbol, string quoteSymbol)
        {
            return await GetByExpression<AzureTableStockPairModel>(x => x.PartitionKey == baseSymbol && x.RowKey == quoteSymbol);
        }

        public async Task Upsert(AzureTableStockPairModel azureTableStockModel)
        {
            await AddEditEntity(azureTableStockModel);
        }
    }
}