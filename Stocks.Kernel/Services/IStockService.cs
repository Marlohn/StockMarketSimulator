using Stocks.Kernel.Models;

namespace Stocks.Kernel.Services
{
    public interface IStockService
    {
        Task<StockDto> Get(string stockSymbol);
        Task<List<StockDto>> GetAll();
    }
}