using RestSharp;
using System.Net;

namespace HTTP.Connector
{
    public class GenericHttpResponse<T>
    {
        public bool IsSuccessful { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }

        public GenericHttpResponse(RestResponse<T> restResponse)
        {
            IsSuccessful = restResponse.IsSuccessful;
            StatusCode = restResponse.StatusCode;
            ErrorMessage = restResponse.ErrorMessage;
            Data = restResponse.Data;
        }
    }
}