using Wallets.Kernel.Application.Models;

namespace Wallets.Kernel.Domain.Repositories
{
    public interface IWalletsRepository
    {
        Task Upsert(AzureTableWalletModel azureTableStockModel);
        Task<AzureTableWalletModel?> Get(Guid walletId, string stockName);
        Task<List<AzureTableWalletModel>> GetAll(Guid walletId);
    }
}