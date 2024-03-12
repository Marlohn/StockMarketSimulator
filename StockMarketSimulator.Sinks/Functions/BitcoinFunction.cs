using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using StockMarketSimulator.Sinks.Kernel.Services;

namespace StockMarketSimulator.Sinks.Functions
{
    public class BitcoinFunction
    {
        private readonly ILogger _logger;
        private readonly ISinksServices _sinksServices;

        public BitcoinFunction(ILoggerFactory loggerFactory, ISinksServices sinksServices)
        {
            _sinksServices = sinksServices;
            _logger = loggerFactory.CreateLogger<BitcoinFunction>();
        }

        [Function("BitcoinFunction")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer) //5min
        //public void Run([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer) //5sec
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            _sinksServices.UpsertStock(new());

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}