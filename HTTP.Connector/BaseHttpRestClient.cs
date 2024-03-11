using RestSharp;

namespace HTTP.Connector
{
    public abstract class BaseHttpRestClient
    {
        private readonly RestClient _client;

        protected BaseHttpRestClient()
        {
            _client = new RestClient();
        }

        protected BaseHttpRestClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        protected void AddDefaultHeader(string name, string value)
        {
            _client.AddDefaultHeader(name, value);
        }

        protected static RestRequest CreateRequest(string resource, Method method)
        {
            return new RestRequest(resource, method);
        }

        protected static RestRequest AddParameter(RestRequest request, string key, string value)
        {
            request.AddParameter(key, value);
            return request;
        }

        protected async Task<RestResponse<T>> ExecuteRequestAsync<T>(RestRequest request) where T : class
        {
            return await _client.ExecuteAsync<T>(request);
        }

        protected async Task<RestResponse> ExecuteRequestAsync(RestRequest request)
        {
            return await _client.ExecuteAsync(request);
        }
    }
}
