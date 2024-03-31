using StockMarketSimulator.StockPairs.Kernel.Models;
using StockMarketSimulator.StockPairs.Kernel.Services;
using StockMarketSimulator.Stocks.Kernel.Models;
using StockMarketSimulator.Stocks.Kernel.Services;
using StockMarketSimulator.Wallets.Kernel.Infrastructure.Repository;
using StockMarketSimulator.Wallets.Kernel.Models;

namespace StockMarketSimulator.Wallets.Kernel.Services
{
    public class WalletsService : IWalletsService
    {
        private readonly IWalletsRepository _walletsRepository;
        private readonly IStockPairsService _stockPairsService;
        private readonly IStockService _stockService;

        public WalletsService(IWalletsRepository walletsRepository, IStockPairsService stockPairsService, IStockService stockService)
        {
            _walletsRepository = walletsRepository;
            _stockPairsService = stockPairsService;
            _stockService = stockService;
        }

        public async Task<WalletDto> Get(Guid walletId)
        {
            List<AzureTableWalletModel> azureTableUserModels = await _walletsRepository.GetAll(walletId);

            List<StockDto> stocks = await _stockService.GetAll();

            //ToDo: Create Validator

            var walletDto = new WalletDto
            {
                WalletId = walletId,
                Assets = azureTableUserModels.Select(x => new AssetDTO
                {
                    StockSymbol = x.StockSymbol,
                    StockName = stocks.Single(stock => stock.Symbol == x.StockSymbol).Name,
                    StockType = stocks.Single(stock => stock.Symbol == x.StockSymbol).Type,
                    Balance = x.Balance
                }).ToList()
            };

            return walletDto;
        }

        public async Task Deposit(Guid walletId, string stockSymbol, float quantity)
        {
            await _walletsRepository.Upsert(new AzureTableWalletModel()
            {
                // maybe we will not use it
            }
            );
        }

        public async Task Deposit(Guid walletId, string stockSymbol, double quantity)
        {
            //Todo: Create Validator (quantity > 0 for ex)

            //ToDo: SHould request directly form repo?
            //StockPairDTO azureTableStockPairModel = await _stockPairsService.Get(baseSymbol, quoteSymbol);

            AzureTableWalletModel? azureTableUserModel = await _walletsRepository.Get(walletId, stockSymbol);

            var azureTableWalletModel = new AzureTableWalletModel()
            {
                PartitionKey = walletId.ToString(),
                RowKey = stockSymbol,
                WalletId = walletId.ToString(),
                StockSymbol = stockSymbol,
                Balance = azureTableUserModel is null ? quantity : (azureTableUserModel.Balance + quantity)
            };

            await _walletsRepository.Upsert(azureTableWalletModel);
        }

        public async Task Withdraw(Guid walletId, string stockSymbol, float quantity)
        {
            //Todo: Create Validator

            AzureTableWalletModel? azureTableUserModel = await _walletsRepository.Get(walletId, stockSymbol);

            if (azureTableUserModel is not null)
            {
                var azureTableWalletModel = new AzureTableWalletModel()
                {
                    PartitionKey = walletId.ToString(),
                    RowKey = stockSymbol,
                    Balance = azureTableUserModel is null ? quantity : (azureTableUserModel.Balance - quantity)
                };

                //Todo: validate enough balance

                await _walletsRepository.Upsert(azureTableWalletModel);
            }
        }

        public async Task Exchange(Guid walletId, string baseSymbol, string quoteSymbol, double quantity)
        {
            WalletDto wallet = await Get(walletId);

            StockPairDTO? stockPair = await _stockPairsService.Get(baseSymbol, quoteSymbol);

            if (stockPair is not null)
            {



            }

            // processed by queue?

            //AzureTableWalletModel? azureTableUserModel = await _walletsRepository.Get(walletId, stockName);
            //Wallet should be renamed to Stock?
            //Stock should be renamed to Pair? StockPairs?
            //Assets should be what?
        }

    }
}