using StockMarketSimulator.Users.Kernel.Models;

namespace StockMarketSimulator.Users.Kernel.Infratructure.Repository
{
    public interface IUsersRepository
    {
        Task Create(AzureTableUserModel azureTableStockModel);
        Task<AzureTableUserModel?> Get(string userName);
    }
}