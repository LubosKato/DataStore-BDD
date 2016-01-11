using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DataStore.WebApi.Helpers
{
    class WebApiHelper
    {
        delegate Task<HttpResponseMessage> ExecuteDel(HttpClient client, string requestUri);

        public enum Host
        {
            Task
        }

        public static HttpResponseMessage Get(Host host, string endpoint, HttpRequestMessage request)
        {
            return Execute(host, endpoint, request, (client, requestUri) => client.GetAsync(requestUri));
        }

        public static HttpResponseMessage Post(Host host, string endpoint, HttpRequestMessage request, HttpContent content)
        {
            return Execute(host, endpoint, request, (client, requestUri) => client.PostAsync(requestUri, content));
        }

        public static HttpResponseMessage Put(Host host, string endpoint, HttpRequestMessage request, HttpContent content)
        {
            return Execute(host, endpoint, request, (client, requestUri) => client.PutAsync(requestUri, content));
        }

        public static HttpResponseMessage Delete(Host host, string endpoint, HttpRequestMessage request)
        {
            return Execute(host, endpoint, request, (client, requestUri) => client.DeleteAsync(requestUri));
        }

        static string GetHost(Host host)
        {
            return
                System.Configuration.ConfigurationManager.AppSettings[string.Format("EndpointRoot{0}", host)];
        }

        static HttpResponseMessage Execute(Host host, string endpoint, HttpRequestMessage request, ExecuteDel command)
        {
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(GetHost(host));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return command.Invoke(client, string.Concat(endpoint, request.RequestUri.Query)).Result;
            }
        }
    }
}