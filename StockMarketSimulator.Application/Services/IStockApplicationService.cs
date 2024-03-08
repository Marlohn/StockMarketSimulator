using StockMarketSimulator.Application.Dtos;

namespace StockMarketSimulator.Application.Services
{
    public interface IStockApplicationService
    {
        Task UpsertStock(StockDto stockDto);
    }
}
