using StockMarketSimulator.Application.Dtos;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Services
{
    public interface IStockRepository
    {
        Task UpsertStock(AzureTableStockModel azureTableStockModel);
        //Task<string> GetUserProfileByEmail(string email, CancellationToken cancellationToken);
    }
}