using StockPairs.Kernel.Application.Dtos;

namespace StockPairs.Kernel.Domain.Services
{
    public interface IQueueProcessStockPairsService
    {
        Task Send(StockPairDTO stockPair);
    }
}
