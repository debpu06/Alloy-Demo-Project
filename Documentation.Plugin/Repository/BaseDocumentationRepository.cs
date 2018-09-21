using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Documentation.Plugin.Repository
{
    public class BaseDocumentationRepository
    {
        protected HttpClient _client;

        /// <summary>
        /// builds http client with a basic auth header using the provided username and token.
        /// </summary>
        /// <param name="userName">api user</param>
        /// <param name="token">api authorization token</param>
        protected void BuildHttpClient(string userName, string token)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.github.com");
            _client.DefaultRequestHeaders.Authorization = GetBasicAuthHeader(userName, token);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("User-Agent", "Anything");
        }

        private AuthenticationHeaderValue GetBasicAuthHeader(string userName, string token)
        {
            string format = $"{userName}:{token}";
            string authString = Convert.ToBase64String(Encoding.ASCII.GetBytes(format));
            return new AuthenticationHeaderValue("Basic", authString);
        }

        /// <summary>
        /// Returns the response of the request url as a string on status code 200 reponse. Otherwise returns empty string 
        /// </summary>
        /// <param name="requestUrl">url of request</param>
        /// <returns>string response</returns>
        protected string GetDocumentationData(string requestUrl)
        {
            using (var httpResponse = _client.GetAsync(requestUrl).Result)
            {
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                    return string.Empty;

                return httpResponse.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
