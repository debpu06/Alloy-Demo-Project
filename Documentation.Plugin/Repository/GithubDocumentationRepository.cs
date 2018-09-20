using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Documentation.Plugin.Infrastructure;
using Documentation.Plugin.Interfaces;

namespace Documentation.Plugin.Repository
{
    public class GithubDocumentationRepository : IDocumentationRepository
    {
        private GithubConfigurationOptions _configurationOptions;

        public GithubDocumentationRepository(IConfigurationOptions configurationOptions)
        {
            _configurationOptions = configurationOptions as GithubConfigurationOptions;
            if (_configurationOptions == null)
            {
                throw new ArgumentException(typeof(GithubConfigurationOptions).FullName);
            }
            InitializeHttpClient();
        }
        public string GetDocumentationById(string reference)
        {
            reference = "readme.md";
            var data = GetConfluenceDocument(reference);
            throw new NotImplementedException();
        }



        #region API Calls
        private HttpClient _client;
    
        private void InitializeHttpClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.github.com");
            _client.DefaultRequestHeaders.Authorization = GetBasicAuthHeader(_configurationOptions.GithubRepositoryOwner, _configurationOptions.GithubApiToken);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("User-Agent", "Anything");
        }

        private AuthenticationHeaderValue GetBasicAuthHeader(string userName, string token)
        {
            string format = $"{userName}:{token}";
            string authString = Convert.ToBase64String(Encoding.ASCII.GetBytes(format));
            return new AuthenticationHeaderValue("Basic", authString);
        }

        private string GetConfluenceDocument(string confluenceId)
        {
            using (var httpResponse = _client.GetAsync($"/repos/" +
                                                       $"{_configurationOptions.GithubRepositoryOwner}/" +
                                                       $"{_configurationOptions.GithubRepositoryName}" +
                                                       $"/contents/{_configurationOptions.GithubDocumentationFolder}/{confluenceId}?branch={_configurationOptions.GithubBranch}").Result)


            {
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                    return string.Empty;

                return httpResponse.Content.ReadAsStringAsync().Result;
            }
        }

        #endregion
    }
}
