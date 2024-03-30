using StockMarketSimulator.Stocks.Kernel.Models;

namespace StockMarketSimulator.Stocks.Kernel.Infrastructure.Repository
{
    public interface IStockRepository
    {
        Task<AzureTableStockModel?> Get(string stockSymbol);
        Task<List<AzureTableStockModel>> GetAll();
    }
}