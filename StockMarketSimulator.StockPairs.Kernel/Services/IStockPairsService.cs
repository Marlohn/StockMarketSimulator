using StockMarketSimulator.StockPairs.Kernel.Models;

namespace StockMarketSimulator.StockPairs.Kernel.Services
{
    public interface IStockPairsService
    {
        Task<StockPairDTO> Get(string baseSymbol, string quoteSymbol);
        Task Upsert(StockPairDTO stockPairDTO);
    }
}