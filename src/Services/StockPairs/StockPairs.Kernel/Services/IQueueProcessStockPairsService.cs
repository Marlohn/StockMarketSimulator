using StockPairs.Kernel.Models;

namespace StockPairs.Kernel.Services
{
    public interface IQueueProcessStockPairsService
    {
        Task Send(StockPairDTO stockPair);
    }
}
