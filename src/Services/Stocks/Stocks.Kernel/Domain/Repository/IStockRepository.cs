using Stocks.Kernel.Application.Models;

namespace Stocks.Kernel.Domain.Repository
{
    public interface IStockRepository
    {
        Task<AzureTableStockModel?> Get(string stockSymbol);
        Task<List<AzureTableStockModel>> GetAll();
    }
}