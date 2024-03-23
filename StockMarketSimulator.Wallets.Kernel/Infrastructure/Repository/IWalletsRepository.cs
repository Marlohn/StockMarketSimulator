using StockMarketSimulator.Wallets.Kernel.Models;

namespace StockMarketSimulator.Wallets.Kernel.Infrastructure.Repository
{
    public interface IWalletsRepository
    {
        Task Upsert(AzureTableWalletModel azureTableStockModel);
    }
}