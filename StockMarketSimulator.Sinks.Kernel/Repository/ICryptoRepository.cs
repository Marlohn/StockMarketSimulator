using HTTP.Connector.Models;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Repository
{
    public interface ICryptoRepository
    {
        Task<GenericHttpResponse<ApiNinjasResponse>> GetBitcoinPrice();
    }
}