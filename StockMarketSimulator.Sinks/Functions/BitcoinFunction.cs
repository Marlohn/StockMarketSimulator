using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using StockMarketSimulator.Sinks.Kernel.Services;

namespace StockMarketSimulator.Sinks.Functions
{
    public class BitcoinFunction
    {
        private readonly ILogger _logger;
        private readonly ISinksService _sinksServices;

        public BitcoinFunction(ILoggerFactory loggerFactory, ISinksService sinksServices)
        {
            _sinksServices = sinksServices;
            _logger = loggerFactory.CreateLogger<BitcoinFunction>();
        }

        //[Function(nameof(BitcoinTimerFunction))]
        //public async Task BitcoinTimerFunction([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer) //5min
        ////public void Run([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer) //5sec
        //{
        //    _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        //    await UpdateBtc();

        //    if (myTimer.ScheduleStatus is not null)
        //    {
        //        _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        //    }
        //}


        [Function(nameof(BitcoinHttpFunction))]
        public async Task<IActionResult> BitcoinHttpFunction([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            await UpdateBtc();

            return new OkObjectResult("Welcome to Azure Functions!");
        }

        private async Task UpdateBtc()
        {
            await _sinksServices.UpdateBtc();
        }

    }
}