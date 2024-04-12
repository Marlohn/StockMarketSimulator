using HTTP.Connector.Models;
using Sinks.Kernel.Models;

namespace Sinks.Kernel.Infrastructure.Repository
{
    public interface IFiatRepository
    {
        Task<GenericHttpResponse<AwesomeApiUsdBrlResponse>> GetUsdPrice();
    }
}