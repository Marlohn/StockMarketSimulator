using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using StockMarketSimulator.Application.Services;

namespace StockMarketSimulator.Sinks.Functions
{
    public class BitcoinFunction
    {
        private readonly IStockApplicationService _stockApplicationService;
        private readonly ILogger _logger;

        public BitcoinFunction(ILoggerFactory loggerFactory, IStockApplicationService stockApplicationService)
        {
            _stockApplicationService = stockApplicationService;
            _logger = loggerFactory.CreateLogger<BitcoinFunction>();

        }

        [Function("BitcoinFunction")]
        //public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer) //5min
        public void Run([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer) //5sec
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            _stockApplicationService.UpsertStock(null);
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}