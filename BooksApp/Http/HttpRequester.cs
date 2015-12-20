using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace BooksApp.Http
{
    public static class HttpRequester
    {
        public async static Task<T> Get<T>(string url, IDictionary<string, string> headers = null)
        {
            return await Send<T>(url,HttpMethod.Get, null, headers);
        }

        public static async Task<T> Post<T>(string url, object data, IDictionary<string, string> headers = null)
        {
            return await Send<T>(url, HttpMethod.Post, data, headers);            
        }

        private static async Task<T> Send<T>(string url,HttpMethod method, object data = null, IDictionary<string, string> headers = null)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            var request = new HttpRequestMessage(method, new Uri(url));

            if (data != null)
            {
                var content = JsonConvert.SerializeObject(data);
                request.Content = new HttpStringContent(content, UnicodeEncoding.Utf8, "application/json");

            }

            var response = await httpClient.SendRequestAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
