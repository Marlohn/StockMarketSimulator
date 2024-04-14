using StockPairs.Kernel.Application.Models;

namespace StockPairs.Kernel.Domain.Repository
{
    public interface IStockPairsRepository
    {
        Task<AzureTableStockPairModel?> Get(string baseSymbol, string quoteSymbol);
        Task Upsert(AzureTableStockPairModel azureTableStockModel);
    }
}