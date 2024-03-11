using RestSharp;

namespace HTTP.Connector
{
    public class GenericConnector : BaseHttpRestClient, IGenericConnector
    {
        public GenericConnector()
        {
            //AddDefaultHeader("Access-Key", ultracommercePrivateApiOptions.AccessKey);
            //AddDefaultHeader("Access-Key-Secret", ultracommercePrivateApiOptions.AccessKeySecret);
        }

        public async Task RequestBtc()
        {
            RestRequest request = CreateRequest("https://api.api-ninjas.com/v1/cryptoprice?symbol=BTCUSDC", Method.Get);

            request.AddHeader("X-Api-Key", "BAminvR56fKF1cg2AY+pdg==Iu1yF8xvLeG8vNp7");

            RestResponse response = await ExecuteRequestAsync(request);
        }
    }
}
