using RestSharp;
using ReqresApiAutomation.Config;

namespace ReqresApiAutomation.Clients
{
    public class ReqresClient
    {
        private readonly RestClient _client;

        public ReqresClient()
        {
            _client = new RestClient(TestConfig.BaseUrl);
        }

        private RestRequest CreateRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("x-api-key", TestConfig.ApiKey);
            return request;
        }

        public RestResponse GetUser(int userId)
        {
            var request = CreateRequest($"/users/{userId}", Method.Get);
            return _client.Execute(request);
        }

        public RestResponse PostUser(object body)
        {
            var request = CreateRequest("/users", Method.Post);
            request.AddJsonBody(body);
            return _client.Execute(request);
        }

        public RestResponse UpdateUser(int userId, object body)
        {
            var request = CreateRequest($"/users/{userId}", Method.Put);
            request.AddJsonBody(body);
            return _client.Execute(request);
        }

        public RestResponse PatchUser(int userId, object body)
        {
            var request = CreateRequest($"/users/{userId}", Method.Patch);
            request.AddJsonBody(body);
            return _client.Execute(request);
        }

        public RestResponse DeleteUser(int userId)
        {
            var request = CreateRequest($"/users/{userId}", Method.Delete);
            return _client.Execute(request);
        }
    }
}
