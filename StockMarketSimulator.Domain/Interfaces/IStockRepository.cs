using StockMarketSimulator.Domain.Models;

namespace StockMarketSimulator.Domain.Interfaces
{
    public interface IStockRepository
    {
        Task Upsert(Stock stock);
    }
}