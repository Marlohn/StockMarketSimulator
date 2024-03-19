using HTTP.Connector.Models;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Repository
{
    public interface IFiatRepository
    {
        Task<GenericHttpResponse<AwesomeApiUsdBrlResponse>> GetUsdPrice();
    }
}