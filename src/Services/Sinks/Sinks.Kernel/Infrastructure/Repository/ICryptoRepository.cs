using HTTP.Connector.Models;
using Sinks.Kernel.Models;

namespace Sinks.Kernel.Infrastructure.Repository
{
    public interface ICryptoRepository
    {
        Task<GenericHttpResponse<ApiNinjasResponse>> GetBitcoinPrice();
    }
}