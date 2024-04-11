using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using StockMarketSimulator.StockPairs.Kernel.Models;
using StockMarketSimulator.StockPairs.Kernel.Services;

namespace StockMarketSimulator.Sinks.Functions
{
    public class ProcessStockPairs
    {
        private readonly IStockPairsService _stockPairsService;

        private readonly ILogger<ProcessStockPairs> _logger;

        public ProcessStockPairs(ILogger<ProcessStockPairs> logger, IStockPairsService stockPairsService)
        {
            _stockPairsService = stockPairsService;
            _logger = logger;
        }

        [Function(nameof(ProcessStockPairs))]
        public async Task Run([QueueTrigger("process-stockpairs")] StockPairDTO stockPair)
        {
            await _stockPairsService.Upsert(stockPair);
        }
    }
}
