using StockMarketSimulator.Domain.Models;

namespace StockMarketSimulator.Domain.Services
{
    public interface IStockService
    {
        Task Upsert(Stock stock);
    }
}