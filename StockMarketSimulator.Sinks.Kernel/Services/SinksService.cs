using HTTP.Connector.Models;
using StockMarketSimulator.Sinks.Kernel.Constants;
using StockMarketSimulator.Sinks.Kernel.Models;
using StockMarketSimulator.Sinks.Kernel.Models.Interfaces;
using StockMarketSimulator.Sinks.Kernel.Repository;

namespace StockMarketSimulator.Sinks.Kernel.Services
{
    public class SinksService : ISinksServices
    {
        private readonly IStockRepository _stockRepository;
        private readonly ICryptoRepository _cryptoRepository;
        private readonly IFiatRepository _fiatRepository;

        public SinksService(IStockRepository stockRepository, ICryptoRepository cryptoRepository, IFiatRepository fiatRepository)
        {
            _stockRepository = stockRepository;
            _cryptoRepository = cryptoRepository;
            _fiatRepository = fiatRepository;
        }

        public async Task UpdateBtc()
        {
            GenericHttpResponse<ApiNinjasResponse> response = await _cryptoRepository.GetBitcoinPrice();

            await UpsertStock(response, StockTypes.Crypto, StockNames.Bitcoin);
        }

        public async Task UpdateUsd()
        {
            GenericHttpResponse<AwesomeApiUsdBrlResponse> response = await _fiatRepository.GetUsdPrice();

            await UpsertStock(response, StockTypes.Fiat, StockNames.Dollar);
        }

        private async Task UpsertStock<T>(GenericHttpResponse<T> response, string stockType, string stockName) where T : IStockDataExtractor
        {
            if (response.IsSuccessful && response.Data != null)
            {
                // Todo: Create Validator
                // ToDo: Create Mapper
                var azureTableStockModel = new AzureTableStockModel()
                {
                    PartitionKey = stockType,
                    RowKey = response.Data.GetSymbol(),
                    Symbol = response.Data.GetSymbol(),
                    Name = stockName,
                    Price = response.Data.GetPrice(),
                };

                await _stockRepository.UpsertStock(azureTableStockModel);
            }
        }


    }
}