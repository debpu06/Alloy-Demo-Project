using System;
using Documentation.Plugin.Infrastructure;
using Documentation.Plugin.Interfaces;

namespace Documentation.Plugin.Repository
{
    public class ConfluenceDocumentationRepository : IDocumentationRepository
    {
        private ConfluenceConfigurationOptions _configurationOptions;
        public ConfluenceDocumentationRepository(IConfigurationOptions configurationOptions)
        {
            _configurationOptions = configurationOptions as ConfluenceConfigurationOptions;
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
