using EPiServer.Core;

namespace Alloy_Demo_Site.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
