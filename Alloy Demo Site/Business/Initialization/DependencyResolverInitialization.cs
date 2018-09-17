using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Alloy_Demo_Site.Business.Rendering;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;
using Documentation.Plugin;
using Documentation.Plugin.Infrastructure;

namespace Alloy_Demo_Site.Business.Initialization
{
    [InitializableModule]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            //Implementations for custom interfaces can be registered here.

            context.ConfigurationComplete += (o, e) =>
            {
                //Register custom implementations that should be used in favour of the default implementations
                context.Services.AddTransient<IContentRenderer, ErrorHandlingContentRenderer>()
                    .AddTransient<ContentAreaRenderer, AlloyContentAreaRenderer>();
            };
            context.InitializeDocumentationPlugin();
        }

        public void Initialize(InitializationEngine context)
        {
            DependencyResolver.SetResolver(new ServiceLocatorDependencyResolver(context.Locate.Advanced));
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}
