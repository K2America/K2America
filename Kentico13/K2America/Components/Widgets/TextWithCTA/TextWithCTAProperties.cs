using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace K2America.Components.Widgets
{
    public class TextWithCTAProperties : IWidgetProperties
    {
        [EditingComponent(RichTextComponent.IDENTIFIER, Order = 1, Label = "Title")]
        [Required(ErrorMessage = "This field is required")]
        public string Title { get; set; }
        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 2, Label = "Description")]
        public string Description { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "CTA Text")]
        public string CTAText { get; set; }

        [EditingComponent(UrlSelector.IDENTIFIER, Order = 4, Label = "CTA Link")]
        public string CTALink { get; set; }
    }
}
