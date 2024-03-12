using StockMarketSimulator.Application.Dtos;

namespace StockMarketSimulator.Sinks.Kernel.Services
{
    public interface ISinksServices
    {
        Task UpsertStock(StockDto stockDto);
    }
}