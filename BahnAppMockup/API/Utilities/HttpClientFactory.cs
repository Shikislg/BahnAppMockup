using BahnAppMockup.API.Interfaces;
using BahnAppMockup.API.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BahnAppMockup.API.Utilities
{
    public static class HttpClientFactory
    {
        public static HttpClient CreateClient(string baseUrl)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public static ApiService CreateApiService()
        {
            return new ApiService(CreateClient(ConfigurationManager.AppSettings["ApiBaseUrl"]));
        }
    }

}
