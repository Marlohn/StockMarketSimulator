using StockMarketSimulator.Application.Services;

namespace StockMarketSimulator.Sinks.Kernel.Services
{
    public class SinksService : ISinksServices
    {
        private readonly IStockApplicationService _stockApplicationService;

        public SinksService(IStockApplicationService stockApplicationService)
        {
            _stockApplicationService = stockApplicationService;
        }
    }
}