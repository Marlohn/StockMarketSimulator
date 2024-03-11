using StockMarketSimulator.Application.Dtos;
using StockMarketSimulator.Domain.Services;

namespace StockMarketSimulator.Application.Services
{
    public class StockApplicationService : IStockApplicationService
    {
        private readonly IStockService _stockService;

        public StockApplicationService(IStockService stockService)
        {
            _stockService = stockService;
        }

        public async Task UpsertStock(StockDto stockDto)
        {
            //_stockService.
            throw new NotImplementedException();
        }
    }
}