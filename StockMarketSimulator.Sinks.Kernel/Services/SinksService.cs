using HTTP.Connector;
using StockMarketSimulator.Application.Dtos;
using StockMarketSimulator.Application.Services;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Services
{
    public class SinksService : ISinksServices
    {
        private readonly IStockApplicationService _stockApplicationService;
        private readonly IGenericHttpClient _genericConnector;

        public SinksService(IGenericHttpClient genericConnector)
        {
            //_stockApplicationService = stockApplicationService;
            _genericConnector = genericConnector;
        }

        public async Task UpsertStock(StockDto stockDto)
        {
            GenericHttpResponse<ApiNinjasResponseModel> response = 
                await _genericConnector.GetBitcoinPrice();

            if (response.IsSuccessful)
            {
                var test = _stockApplicationService.UpsertStock(stockDto);
            }
        }
    }
}