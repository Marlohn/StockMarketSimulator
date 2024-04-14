using Users.Kernel.Application.Models;

namespace Users.Kernel.Domain.Repository
{
    public interface IUsersRepository
    {
        Task Create(AzureTableUserModel azureTableStockModel);
        Task<AzureTableUserModel?> Get(string userName);
    }
}