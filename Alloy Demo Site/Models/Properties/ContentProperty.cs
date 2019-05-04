using EPiServer.Core;
using EPiServer.PlugIn;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alloy_Demo_Site.Models.Properties
{
    public class ContentProperty
    {
        [Display(Name = "Title Content")]
        public virtual string Title { get; set; }

        [Display(Name = "Rich Text Content")]
        public virtual XhtmlString MainContentArea { get; set; }
    }

    [PropertyDefinitionTypePlugIn]
    public class ContentPropertyListTypeDefinition : PropertyList<ContentProperty>
    {
    }
}