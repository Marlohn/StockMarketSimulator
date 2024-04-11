using StockMarketSimulator.Stocks.Kernel.Models;

namespace StockMarketSimulator.Stocks.Kernel.Services
{
    public interface IStockService
    {
        Task<StockDto> Get(string stockSymbol);
        Task<List<StockDto>> GetAll();
    }
}