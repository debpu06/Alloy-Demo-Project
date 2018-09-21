using Documentation.Plugin.Interfaces;
using Documentation.Plugin.Repository;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Documentation.Plugin.Controllers;
using System.Reflection;

namespace Documentation.Plugin.Infrastructure
{
    /// <summary>
    /// Extension methods for service configuration
    /// </summary>
    public static class ServiceConfigurationContextExtensions
    {
        /// <summary>
        /// Registers singletons for GithubDocumentationRepository and
        /// GithubConfigurationOptions
        /// </summary>
        /// <param name="context">instance of ServiceConfiguration</param>
        /// <param name="options">Github configuration options</param>
        public static void InitializeDocumentationPlugin(this ServiceConfigurationContext context, GithubConfigurationOptions options)
        {
            context.Services.AddSingleton<IDocumentationRepository, GithubDocumentationRepository>();
            context.Services.AddSingleton<IConfigurationOptions, GithubConfigurationOptions>(locator => options);
        }

        /// <summary>
        /// Registers singletons for ConfluenceDocumentationRepository and
        /// ConfluenceConfigurationOptions 
        /// </summary>
        /// <param name="context">instance of ServiceConfiguration</param>
        /// <param name="options">Confluence configuration options</param>
        public static void InitializeDocumentationPlugin(this ServiceConfigurationContext context, ConfluenceConfigurationOptions options)
        {
            context.Services.AddSingleton<IDocumentationRepository, ConfluenceDocumentationRepository>();
            context.Services.AddSingleton<IConfigurationOptions, ConfluenceConfigurationOptions>(locator => options);
        }
    }
}
