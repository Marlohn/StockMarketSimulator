using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Infrastructure.Repository
{
    public interface IStockRepository
    {
        Task Upsert(AzureTableStockModel azureTableStockModel);
        //Task<string> GetUserProfileByEmail(string email, CancellationToken cancellationToken);
    }
}