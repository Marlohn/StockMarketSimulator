using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Sinks.Kernel.Domain.Services;

namespace Sinks.Functions.Functions
{
    public class DollarFunction
    {
        private readonly ILogger _logger;
        private readonly ISinksService _sinksServices;

        public DollarFunction(ILoggerFactory loggerFactory, ISinksService sinksServices)
        {
            _sinksServices = sinksServices;
            _logger = loggerFactory.CreateLogger<DollarFunction>();
        }

        //[Function(nameof(DollarTimerFunction))]
        //public async Task DollarTimerFunction([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer) //5min
        ////public void Run([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer) //5sec
        //{
        //    _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        //    await UpdateUsd();

        //    if (myTimer.ScheduleStatus is not null)
        //    {
        //        _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        //    }
        //}


        [Function(nameof(DollarHttpFunction))]
        public async Task<IActionResult> DollarHttpFunction([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            await UpdateUsd();

            return new OkObjectResult("Welcome to Azure Functions!");
        }

        private async Task UpdateUsd()
        {
            await _sinksServices.UpdateUsd();
        }
    }
}
