using Stocks.Kernel.Application.Dtos;

namespace Stocks.Kernel.Domain.Services
{
    public interface IStockService
    {
        Task<StockDto> Get(string stockSymbol);
        Task<List<StockDto>> GetAll();
    }
}