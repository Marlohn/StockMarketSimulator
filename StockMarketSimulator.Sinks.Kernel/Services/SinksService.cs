using HTTP.Connector;
using StockMarketSimulator.Application.Dtos;
using StockMarketSimulator.Application.Services;

namespace StockMarketSimulator.Sinks.Kernel.Services
{
    public class SinksService : ISinksServices
    {
        //private readonly IStockApplicationService _stockApplicationService;
        private readonly IGenericConnector _genericConnector;

        public SinksService(IGenericConnector genericConnector)
        {
            //_stockApplicationService = stockApplicationService;
            _genericConnector = genericConnector;
        }

        public async Task UpsertStock(StockDto stockDto)
        {
            await _genericConnector.RequestBtc();
            throw new NotImplementedException();
        }
    }
}