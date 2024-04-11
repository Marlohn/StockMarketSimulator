using HTTP.Connector.Models;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Infrastructure.Repository
{
    public interface ICryptoRepository
    {
        Task<GenericHttpResponse<ApiNinjasResponse>> GetBitcoinPrice();
    }
}