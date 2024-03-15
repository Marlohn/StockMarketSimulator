using HTTP.Connector.Models;
using StockMarketSimulator.Sinks.Kernel.Constants;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Services
{
    public class SinksService : ISinksServices
    {
        private readonly IStockRepository _stockRepository;
        private readonly IGenericHttpClient _genericConnector;

        public SinksService(IStockRepository stockRepository, IGenericHttpClient genericConnector)
        {
            _stockRepository = stockRepository;
            _genericConnector = genericConnector;
        }

        public async Task UpdateBtc()
        {
            GenericHttpResponse<ApiNinjasResponseModel> response =
                await _genericConnector.GetBitcoinPrice();

            await UpsertStock(response, StockTypes.Crypto, StockNames.Bitcoin);
        }

        private async Task UpsertStock(GenericHttpResponse<ApiNinjasResponseModel> response, string stockType, string stockName)
        {
            if (response.IsSuccessful && response.Data != null)
            {
                // Todo: Create Validator

                var azureTableStockModel = new AzureTableStockModel()
                {
                    PartitionKey = stockType, //MUST exist
                    RowKey = response.Data.Symbol, //MUST exist
                    Symbol = response.Data.Symbol, //MUST exist
                    Name = stockName, //not null
                    Price = response.Data.Price // not null
                };

                await _stockRepository.UpsertStock(azureTableStockModel);
            }
        }
    }
}