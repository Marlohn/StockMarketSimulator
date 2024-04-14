using HTTP.Connector;
using HTTP.Connector.Models;
using RestSharp;
using Sinks.Kernel.Application.Models.Responses;
using Sinks.Kernel.Domain.Repository;

namespace Sinks.Kernel.Infrastructure.Repository
{
    public class FiatRepository : BaseHttpRestClient, IFiatRepository
    {
        public async Task<GenericHttpResponse<AwesomeApiUsdBrlResponse>> GetUsdPrice()
        {
            RestRequest request = CreateRequest("https://economia.awesomeapi.com.br/json/last/USD-BRL", Method.Get);

            RestResponse<AwesomeApiUsdBrlResponse> response = await ExecuteRequestAsync<AwesomeApiUsdBrlResponse>(request);
            return new GenericHttpResponse<AwesomeApiUsdBrlResponse>(response);
        }
    }
}