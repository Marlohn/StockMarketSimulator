using Stocks.Kernel.Models;

namespace Stocks.Kernel.Infrastructure.Repository
{
    public interface IStockRepository
    {
        Task<AzureTableStockModel?> Get(string stockSymbol);
        Task<List<AzureTableStockModel>> GetAll();
    }
}