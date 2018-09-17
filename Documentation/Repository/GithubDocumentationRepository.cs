using System;
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
        }
        public string GetDocumentationById(string reference)
        {
            throw new System.NotImplementedException();
        }
    }
}
