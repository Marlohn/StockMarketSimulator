using HTTP.Connector;
using HTTP.Connector.Models;
using RestSharp;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Infrastructure.Repository
{
    public class CryptoRepository : BaseHttpRestClient, ICryptoRepository
    {
        public CryptoRepository()
        {
            AddDefaultHeader("X-Api-Key", "BAminvR56fKF1cg2AY+pdg==Iu1yF8xvLeG8vNp7");
        }

        public async Task<GenericHttpResponse<ApiNinjasResponse>> GetBitcoinPrice()
        {
            RestRequest request = CreateRequest("https://api.api-ninjas.com/v1/cryptoprice?symbol=BTCUSDC", Method.Get);

            RestResponse<ApiNinjasResponse> response = await ExecuteRequestAsync<ApiNinjasResponse>(request);
            return new GenericHttpResponse<ApiNinjasResponse>(response);
        }
    }
}