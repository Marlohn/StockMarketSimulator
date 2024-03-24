
using StockMarketSimulator.Wallets.Kernel.Infrastructure.Repository;
using StockMarketSimulator.Wallets.Kernel.Models;

namespace StockMarketSimulator.Wallets.Kernel.Services
{
    public class WalletsService : IWalletsService
    {
        private readonly IWalletsRepository _walletsRepository;
        //private readonly IStocksRepository _stocksRepository;

        public WalletsService(IWalletsRepository walletsRepository)
        {
            _walletsRepository = walletsRepository;
        }

        public async Task<WalletDto> Get(Guid walletId)
        {
            List<AzureTableWalletModel> azureTableUserModels = await _walletsRepository.GetAll(walletId);

            //ToDo: Create Validator

            var walletDto = new WalletDto
            {
                WalletId = walletId,
                Assets = azureTableUserModels.Select(x => new AssetDTO { StockName = x.RowKey, Balance = x.Balance }).ToList()
            };

            return walletDto;
        }

        public async Task CreateOrder(Guid walletId, string stockSymbol, decimal quantity)
        {
            await _walletsRepository.Upsert(new AzureTableWalletModel()
            {
                // maybe we will not use it
            }
            );
        }

        public async Task Deposit(Guid walletId, string stockName, double quantity)
        {
            //Todo: Create Validator (quantity > 0 for ex)

            AzureTableWalletModel? azureTableUserModel = await _walletsRepository.Get(walletId, stockName);

            var azureTableWalletModel = new AzureTableWalletModel()
            {
                PartitionKey = walletId.ToString(),
                RowKey = stockName,
                Balance = azureTableUserModel is null ? quantity : (azureTableUserModel.Balance + quantity)
            };

            await _walletsRepository.Upsert(azureTableWalletModel);
        }

        public async Task Withdraw(Guid walletId, string stockName, double quantity)
        {
            //Todo: Create Validator

            AzureTableWalletModel? azureTableUserModel = await _walletsRepository.Get(walletId, stockName);

            if (azureTableUserModel is not null)
            {
                var azureTableWalletModel = new AzureTableWalletModel()
                {
                    PartitionKey = walletId.ToString(),
                    RowKey = stockName,
                    Balance = azureTableUserModel is null ? quantity : (azureTableUserModel.Balance - quantity)
                };

                //Todo: validate enough balance

                await _walletsRepository.Upsert(azureTableWalletModel);
            }
        }

        public async Task Exchange(Guid walletId, string stockSymbol, double quantity)
        {
            //AzureTableWalletModel? azureTableUserModel = await _walletsRepository.Get(walletId, stockName);
            //Wallet should be renamed to Stock?
            //Stock should be renamed to Pair? StockPairs?
            //Assets should be what?
        }

    }
}