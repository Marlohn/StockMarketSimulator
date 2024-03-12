using StockMarketSimulator.Application.Dtos;
using StockMarketSimulator.Domain.Models;
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
            await _stockService.Upsert(new Stock()
            {
                Symbol = stockDto.Symbol,
                Name = stockDto.Name,
                Price = stockDto.Price
            });
        }
    }
}