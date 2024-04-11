using Wallets.Kernel.Models;

namespace Wallets.Kernel.Services
{
    public interface IWalletsService
    {
        Task<WalletDto> Get(Guid walletId);
        Task Deposit(Guid walletId, string stockSymbol, double quantity);
        Task Withdraw(Guid walletId, string stockSymbol, double quantity);
        Task Exchange(Guid walletId, string baseSymbol, string quoteSymbol, double quantity);
    }
}