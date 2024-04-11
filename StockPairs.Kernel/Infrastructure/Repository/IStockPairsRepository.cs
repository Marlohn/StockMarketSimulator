using StockPairs.Kernel.Models;

namespace StockPairs.Kernel.Infrastructure.Repository
{
    public interface IStockPairsRepository
    {
        Task<AzureTableStockPairModel?> Get(string baseSymbol, string quoteSymbol);
        Task Upsert(AzureTableStockPairModel azureTableStockModel);
    }
}