using EPiServer.ServiceLocation;
using Documentation.Plugin.Confluence.Models;
using Documentation.Plugin.Confluence.Repository;
using Documentation.Plugin.Core.Interfaces;
using Documentation.Plugin.Github.Models;
using Documentation.Plugin.Github.Repository;

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
        public static void InitializeDocumentationPlugin(this ServiceConfigurationContext context, IConfigurationOptions options)
        {
            var githubOptions = options as GithubConfigurationOptions;
            if (githubOptions != null)
            {
                context.Services.AddSingleton<IDocumentationRepository, GithubDocumentationRepository>();
                context.Services.AddSingleton<IConfigurationOptions, GithubConfigurationOptions>(locator => githubOptions);
                return;
            }
            var confluenceOptions = options as ConfluenceConfigurationOptions;
            if (confluenceOptions != null)
            {
                context.Services.AddSingleton<IDocumentationRepository, ConfluenceDocumentationRepository>();
                context.Services.AddSingleton<IConfigurationOptions, ConfluenceConfigurationOptions>(locator => confluenceOptions);
                return;
            }
        }
    }
}
