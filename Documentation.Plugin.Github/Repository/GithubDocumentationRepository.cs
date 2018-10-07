using System;
using Documentation.Plugin.Core.Interfaces;
using Documentation.Plugin.Core.Repository;
using Documentation.Plugin.Github.Models;
using Newtonsoft.Json;

namespace Documentation.Plugin.Github.Repository
{
    public class GithubDocumentationRepository : BaseDocumentationRepository, IDocumentationRepository
    {
        private readonly GithubConfigurationOptions _configurationOptions;

        /// <summary>
        /// Initialize the Github repository by creating the http client for the calls
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if correct configuration options are not set for repository</exception>
        /// <param name="configurationOptions"></param>
        public GithubDocumentationRepository(IConfigurationOptions configurationOptions)
        {
            _configurationOptions = configurationOptions as GithubConfigurationOptions;
            //if for some reason options are not set, throw exception
            if (_configurationOptions == null)
            {
                throw new ArgumentException(typeof(GithubConfigurationOptions).FullName);
            }

            BuildHttpClient(_configurationOptions.GithubRepositoryOwner, _configurationOptions.GithubApiToken);
        }

        /// <summary>
        /// Based on provided markdown filename, grabs the file from Github and converts the markdown to html
        /// </summary>
        /// <param name="reference">Name of markdown file (case sensitive)</param>
        /// <returns>html of markdown file</returns>
        public string GetDocumentationById(string reference)
        {
            var requestUrl =
                $"/repos/{_configurationOptions.GithubRepositoryOwner}/" +
                $"{_configurationOptions.GithubRepositoryName}" +
                $"/contents/{_configurationOptions.GithubDocumentationFolder}/{reference}?ref=" +
                $"{_configurationOptions.GithubBranch}";

            var responseData = GetDocumentationData(requestUrl);

            var deserializedObject = JsonConvert.DeserializeObject<GithubResponse>(responseData);

            var documentMarkdown = GetDocumentationData(deserializedObject.DownloadUrl) ?? string.Empty;
            
            return Markdig.Markdown.ToHtml(documentMarkdown);
        }
    }
}
