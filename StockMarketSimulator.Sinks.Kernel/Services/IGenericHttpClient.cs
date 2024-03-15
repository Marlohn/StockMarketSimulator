using HTTP.Connector.Models;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Services
{
    public interface IGenericHttpClient
    {
        Task<GenericHttpResponse<ApiNinjasResponseModel>> GetBitcoinPrice();
    }
}