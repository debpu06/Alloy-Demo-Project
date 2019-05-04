using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Alloy_Demo_Site.Models.Blocks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Alloy_Demo_Site.Models.Properties;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;

namespace Alloy_Demo_Site.Models.Pages
{
    /// <summary>
    /// Used to present a single product
    /// </summary>
    [SiteContentType(
        GUID = "17583DCD-3C11-49DD-A66D-0DEF0DD601FC",
        GroupName = Global.GroupNames.Products)]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-product.png")]
    [AvailableContentTypes(
        Availability = Availability.Specific,
        IncludeOn = new[] { typeof(StartPage) })]
    public class ProductPage : StandardPage, IHasRelatedContent
    {
        [Required]
        [Display(Order = 305)]
        [UIHint(Global.SiteUIHints.StringsCollection)]
        [CultureSpecific]
        public virtual IList<string> UniqueSellingPoints { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 330)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(IContentData) },new[] { typeof(JumbotronBlock) })]
        public virtual ContentArea RelatedContentArea { get; set; }

        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<ContentProperty>))]
        [Display(
            Name = "Example Property List",
            GroupName = SystemTabNames.Content)]
        public virtual IList<ContentProperty> PropertyListExample { get; set; }
    }
}
