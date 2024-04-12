using StockPairs.Kernel.Models;

namespace StockPairs.Kernel.Services
{
    public interface IStockPairsService
    {
        Task<StockPairDTO> Get(string baseSymbol, string quoteSymbol);
        Task Upsert(StockPairDTO stockPairDTO);
    }
}