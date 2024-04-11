using Wallets.Kernel.Models;

namespace Wallets.Kernel.Infrastructure.Repository
{
    public interface IWalletsRepository
    {
        Task Upsert(AzureTableWalletModel azureTableStockModel);
        Task<AzureTableWalletModel?> Get(Guid walletId, string stockName);
        Task<List<AzureTableWalletModel>> GetAll(Guid walletId);
    }
}