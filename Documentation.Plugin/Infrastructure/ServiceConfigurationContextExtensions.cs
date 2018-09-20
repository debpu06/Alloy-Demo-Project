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
    public static class ServiceConfigurationContextExtensions
    {
        public static void InitializeDocumentationPlugin(this ServiceConfigurationContext context, GithubConfigurationOptions options)
        {
            context.Services.AddSingleton<IDocumentationRepository, GithubDocumentationRepository>();
            context.Services.AddSingleton<IConfigurationOptions, GithubConfigurationOptions>(locator => options);
        }

        public static void InitializeDocumentationPlugin(this ServiceConfigurationContext context, ConfluenceConfigurationOptions options)
        {
            context.Services.AddSingleton<IDocumentationRepository, ConfluenceDocumentationRepository>();
            context.Services.AddSingleton<IConfigurationOptions, ConfluenceConfigurationOptions>(locator => options);
        }
    }
}
