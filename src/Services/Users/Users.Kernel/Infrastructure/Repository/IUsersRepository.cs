using Users.Kernel.Models;

namespace Users.Kernel.Infrastructure.Repository
{
    public interface IUsersRepository
    {
        Task Create(AzureTableUserModel azureTableStockModel);
        Task<AzureTableUserModel?> Get(string userName);
    }
}