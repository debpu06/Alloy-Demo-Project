using Alloy_Demo_Site.Models.Blocks;
using Alloy_Demo_Site.Models.Pages;
using EPiServer.Cms.TinyMce.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace Alloy_Demo_Site.Business.Initialization
{
    [ModuleDependency(typeof(TinyMceInitialization))]
    public class ExtendedTinyMceInitialization : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Configure<TinyMceConfiguration>(config =>
            {
                // Add content CSS to the default settings.
                config.Default()
                    .ContentCss("/static/css/editor.css")
                    .AddSetting("templates", new[]
                    {
                        new
                        {
                            title = "Article Template 1",
                            url = "../../Static/html/templates/article_template_1.html",
                            description = "Template w/title and text"
                        },
                        new
                        {
                            title = "Article Template 2",
                            url = "../../Static/html/templates/article_template_2.html",
                            description = "Template with title and image"
                        }
                    })
                    .AddPlugin("template")
                    .Toolbar("template");
                // This will clone the default settings object and extend it by
                // limiting the block formats for the MainBody property of an ArticlePage.
                config.For<ArticlePage>(t => t.MainBody)
                    .BlockFormats("Paragraph=p;Header 1=h1;Header 2=h2;Header 3=h3");

                // Passing a second argument to For<> will clone the given settings object
                // instead of the default one and extend it with some basic toolbar commands.
                config.For<EditorialBlock>(t => t.MainBody, config.Empty())
                    .Plugins(DefaultValues.EpiserverPlugins)
                    .DisableMenubar()
                    .Toolbar("bold italic underline strikethrough");
            });
        }
    }
}
