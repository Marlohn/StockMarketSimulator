using StockMarketSimulator.Domain.Interfaces;
using StockMarketSimulator.Domain.Models;

namespace StockMarketSimulator.Domain.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task Upsert(Stock stock)
        {
            await _stockRepository.Upsert(stock);
        }
    }
}