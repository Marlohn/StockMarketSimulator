
using StockMarketSimulator.Wallets.Kernel.Models;

namespace StockMarketSimulator.Wallets.Kernel.Services
{
    public interface IWalletsService
    {
        Task<WalletDto> Get(Guid walletId);
        Task Deposit(Guid walletId, string stockSymbol, float quantity);
        Task Withdraw(Guid walletId, string stockSymbol, float quantity);
        Task Exchange(Guid walletId, string baseSymbol, string quoteSymbol, float quantity);
    }
}