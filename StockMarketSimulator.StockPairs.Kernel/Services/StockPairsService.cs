using StockMarketSimulator.Sinks.Kernel.Models;
using StockMarketSimulator.StockPairs.Kernel.Infrastructure.Repository;
using StockMarketSimulator.StockPairs.Kernel.Models;
//using StockMarketSimulator.Stocks.Kernel.Services;

namespace StockMarketSimulator.StockPairs.Kernel.Services
{
    public class StockPairsService : IStockPairsService
    {
        private readonly IStockPairsRepository _stockPairsRepository;
        //private readonly IStockService _stockService;

        public StockPairsService(IStockPairsRepository stockPairsRepository)//, IStockService stockService)
        {
            _stockPairsRepository = stockPairsRepository;
            //_stockService = stockService; ;
        }

        public async Task<StockPairDTO> Get(string baseSymbol, string quoteSymbol)
        {
            AzureTableStockPairModel? azureTableStockPairModel = await _stockPairsRepository.Get(baseSymbol, quoteSymbol);

            //ToDo: check null
            return new StockPairDTO()
            {
                Name = azureTableStockPairModel.Name,
                BaseSymbol = azureTableStockPairModel.BaseSymbol,
                QuoteSymbol = azureTableStockPairModel.QuoteSymbol,
                Price = azureTableStockPairModel.Price
            };
        }

        public async Task Upsert(StockPairDTO stockPairDTO)
        {
            // ToDo: Create Mapper
            var azureTableStockModel = new AzureTableStockPairModel()
            {
                PartitionKey = stockPairDTO.BaseSymbol,
                RowKey = stockPairDTO.QuoteSymbol,
                Name = stockPairDTO.Name,
                BaseSymbol = stockPairDTO.BaseSymbol,
                QuoteSymbol = stockPairDTO.QuoteSymbol,
                Price = stockPairDTO.Price,
            };

            await _stockPairsRepository.Upsert(azureTableStockModel);
        }
    }
}
