
using StockMarketSimulator.Wallets.Kernel.Models;

namespace StockMarketSimulator.Wallets.Kernel.Services
{
    public interface IWalletsService
    {
        Task<WalletDto> Get(Guid walletId);
        Task CreateOrder(Guid walletId, string stockSymbol, decimal quantity);
        Task Deposit(Guid walletId, string stockSymbol, double quantity);
    }
}
