using HTTP.Connector.Models;
using Sinks.Kernel.Application.Models.Responses;

namespace Sinks.Kernel.Domain.Repository
{
    public interface ICryptoRepository
    {
        Task<GenericHttpResponse<ApiNinjasResponse>> GetBitcoinPrice();
    }
}