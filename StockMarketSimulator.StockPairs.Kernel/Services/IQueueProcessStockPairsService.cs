using StockMarketSimulator.StockPairs.Kernel.Models;

namespace StockMarketSimulator.StockPairs.Kernel.Services
{
    public interface IQueueProcessStockPairsService
    {
        Task Send(StockPairDTO stockPair);
    }
}
