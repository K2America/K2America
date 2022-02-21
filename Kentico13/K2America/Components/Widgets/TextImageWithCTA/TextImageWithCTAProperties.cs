using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace K2America.Components.Widgets
{
    public class TextImageWithCTAProperties : IWidgetProperties
    {
        [EditingComponent(RichTextComponent.IDENTIFIER, Order = 1, Label = "Title")]
        [Required(ErrorMessage = "This field is required")]
        public string Title { get; set; }
        [EditingComponent(RichTextComponent.IDENTIFIER, Order = 2, Label = "Description")]
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [EditingComponent(MediaFilesSelector.IDENTIFIER, Order = 3, Label = "Image")]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        public IEnumerable<MediaFilesSelectorItem> Image { get; set; } = Enumerable.Empty<MediaFilesSelectorItem>();

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Image Alternative Text")]
        public string ImageAltText { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 5, Label = "CTA Text")]
        public string CTAText { get; set; }

        [EditingComponent(UrlSelector.IDENTIFIER, Order = 6, Label = "CTA Link")]
        public string CTALink { get; set; }
    }
}
