using HTTP.Connector;
using RestSharp;
using StockMarketSimulator.Sinks.Kernel.Models;

namespace StockMarketSimulator.Sinks.Kernel.Services
{
    public class GenericHttpClient : BaseHttpRestClient, IGenericHttpClient
    {
        public GenericHttpClient()
        {
            AddDefaultHeader("X-Api-Key", "BAminvR56fKF1cg2AY+pdg==Iu1yF8xvLeG8vNp7");
        }


        public async Task<GenericHttpResponse<ApiNinjasResponseModel>> GetBitcoinPrice()
        {
            RestRequest request = CreateRequest("https://api.api-ninjas.com/v1/cryptoprice?symbol=BTCUSDC", Method.Get);

            RestResponse<ApiNinjasResponseModel> response = await ExecuteRequestAsync<ApiNinjasResponseModel>(request);
            return new GenericHttpResponse<ApiNinjasResponseModel>(response);
        }
    }
}
