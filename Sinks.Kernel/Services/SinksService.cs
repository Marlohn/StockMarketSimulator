using HTTP.Connector.Models;
using Sinks.Kernel.Infrastructure.Repository;
using Sinks.Kernel.Models;
using Sinks.Kernel.Models.Interfaces;
using StockPairs.Kernel.Models;
using StockPairs.Kernel.Services;
using Stocks.Kernel.Models;
using Stocks.Kernel.Services;

namespace Sinks.Kernel.Services
{
    public class SinksService : ISinksService
    {
        private readonly ICryptoRepository _cryptoRepository;
        private readonly IFiatRepository _fiatRepository;
        //private readonly IStockPairsService _stockPairsService;
        private readonly IQueueProcessStockPairsService _queueProcessStockPairsService;
        private readonly IStockService _stockService;


        public SinksService(ICryptoRepository cryptoRepository, IFiatRepository fiatRepository, IStockPairsService stockPairsService, IStockService stockService, IQueueProcessStockPairsService queueProcessStockPairsService)
        {
            _cryptoRepository = cryptoRepository;
            _fiatRepository = fiatRepository;
            //_stockPairsService = stockPairsService;
            _stockService = stockService;
            _queueProcessStockPairsService = queueProcessStockPairsService;
        }

        public async Task UpdateBtc()
        {
            GenericHttpResponse<ApiNinjasResponse> response = await _cryptoRepository.GetBitcoinPrice();

            await UpsertStockPair(response);
        }

        public async Task UpdateUsd()
        {
            GenericHttpResponse<AwesomeApiUsdBrlResponse> response = await _fiatRepository.GetUsdPrice();

            await UpsertStockPair(response);
        }

        private async Task UpsertStockPair<T>(GenericHttpResponse<T> response) where T : IStockDataExtractor
        {
            if (response.IsSuccessful && response.Data != null)
            {
                StockDto baseStock = await _stockService.Get(response.Data.GetBaseSymbol());
                StockDto quoteStock = await _stockService.Get(response.Data.GetQuoteSymbol());

                // ToDo: Create Mapper
                var stockPair = new StockPairDTO()
                {
                    BaseSymbol = baseStock.Symbol,
                    QuoteSymbol = quoteStock.Symbol,
                    Name = GenerateStockPairName(baseStock.Symbol, quoteStock.Symbol),
                    Price = response.Data.GetPrice(),
                };

                // Todo: Create Validator

                //TODO: SEND MESSAGE
                await _queueProcessStockPairsService.Send(stockPair);
                //await _stockPairsService.Upsert(stockPair);
            }
        }

        private static string GenerateStockPairName(string baseSymbol, string quoteSymbol)
        {
            return $"{baseSymbol}{quoteSymbol}".ToLowerInvariant();
        }
    }
}