using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace one_football.Services
{
    public class BaseService
    {
        protected HttpClient SetupHttpClient(string baseUrl)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
