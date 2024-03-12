using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using StockMarketSimulator.Application.Services;

namespace FunctionApp1.Functions
{
    public class BitcoinFunction
    {
        private readonly ILogger _logger;

        public BitcoinFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BitcoinFunction>();
        }

        [Function("BitcoinFunction")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
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