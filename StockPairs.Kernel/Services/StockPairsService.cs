using StockPairs.Kernel.Infrastructure.Repository;
using StockPairs.Kernel.Models;

namespace StockPairs.Kernel.Services
{
    public class StockPairsService : IStockPairsService
    {
        private readonly IStockPairsRepository _stockPairsRepository;

        public StockPairsService(IStockPairsRepository stockPairsRepository)
        {
            _stockPairsRepository = stockPairsRepository;
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