using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell;

namespace Documentation.Plugin.Infrastructure
{
    [ServiceConfiguration(typeof(EPiServer.Shell.ViewConfiguration))]
    public class EditorViewConfiguration : ViewConfiguration<PageData>
    {
        public EditorViewConfiguration()
        {
            Key = "EditorViewConfiguration";
            Name = "Editor Documentation";
            Description = "Page Showing Editor Documentation";
            ControllerType = "epi-cms/widget/IFrameController";
            ViewType = "/EditorViewDocumentation/";
            IconClass = "epi-iconForms";
        }
    }
}
