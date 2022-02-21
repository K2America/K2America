using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace K2America.Components.Widgets
{
    public class SlideWidgetProperties : IWidgetProperties
    {
        [EditingComponent(DropDownComponent.IDENTIFIER, Order = 0, Label = "Layout Type", Tooltip = "Please Select a Type")]
        [Required(ErrorMessage = "This field is required")]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "fullwidthimage;Full Width Image\r\nfiftyfiftyimage;Fifty Fifty Image")]
        public string LayoutType { get; set; }
        [EditingComponent(RichTextComponent.IDENTIFIER, Order = 1, Label = "Title")]
        [Required(ErrorMessage = "This field is required")]
        public string Title { get; set; }
        [EditingComponent(RichTextComponent.IDENTIFIER, Order = 2, Label = "Description")]
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [EditingComponent(MediaFilesSelector.IDENTIFIER, Order = 3, Label = "Image")]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        [Required(ErrorMessage = "This field is required")]
        public IEnumerable<MediaFilesSelectorItem> Image { get; set; } = Enumerable.Empty<MediaFilesSelectorItem>();

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Image Alternative Text")]
        public string ImageAltText { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 5, Label = "CTA Text 1")]
        public string CTAText1 { get; set; }

        [EditingComponent(UrlSelector.IDENTIFIER, Order = 6, Label = "CTA Link 1")]
        public string CTALink1 { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 7, Label = "CTA Text 2")]
        public string CTAText2 { get; set; }

        [EditingComponent(UrlSelector.IDENTIFIER, Order = 8, Label = "CTA Link 2")]
        public string CTALink2 { get; set; }
    }
}
