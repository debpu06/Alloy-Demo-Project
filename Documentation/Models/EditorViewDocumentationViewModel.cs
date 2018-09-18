using EPiServer.Core;

namespace Documentation.Plugin.Models
{
    public class EditorViewDocumentationViewModel
    {
        public EditorViewDocumentationViewModel()
        {

        }

        public string DocumentationContent { get; set; }
        public IContent EpiContent { get; set; }
    }
}
