using StockMarketSimulator.Stocks.Kernel.Infrastructure.Repository;
using StockMarketSimulator.Stocks.Kernel.Models;

namespace StockMarketSimulator.Stocks.Kernel.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<StockDto> Get(string stockSymbol)
        {
            AzureTableStockModel? azureTableStockModel = await _stockRepository.Get(stockSymbol);

            return new StockDto()
            {
                Name = azureTableStockModel.Name,
                Symbol = azureTableStockModel.Symbol,
                Type = azureTableStockModel.Type
            };
        }

        public async Task<List<StockDto>> GetAll()
        {
            List<AzureTableStockModel> azureTableStockModels = await _stockRepository.GetAll();

            var stocks = new List<StockDto>();
            foreach (var item in azureTableStockModels)
            {
                stocks.Add(new StockDto()
                {
                    Name = item.Name,
                    Symbol = item.Symbol,
                    Type = item.Type
                });
            }

            return stocks;
        }
    }
}