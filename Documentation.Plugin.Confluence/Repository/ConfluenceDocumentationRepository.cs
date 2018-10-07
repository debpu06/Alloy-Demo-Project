using System;
using Documentation.Plugin.Confluence.Models;
using Documentation.Plugin.Core.Interfaces;

namespace Documentation.Plugin.Confluence.Repository
{
    public class ConfluenceDocumentationRepository : IDocumentationRepository
    {
        private readonly ConfluenceConfigurationOptions _configurationOptions;
        public ConfluenceDocumentationRepository(IConfigurationOptions configurationOptions)
        {
            _configurationOptions = configurationOptions as ConfluenceConfigurationOptions;
            if (_configurationOptions == null)
            {
                throw new ArgumentException(typeof(ConfluenceConfigurationOptions).FullName);
            }
        }

        public string GetDocumentationById(string reference)
        {
            throw new System.NotImplementedException();
        }
    }
}
