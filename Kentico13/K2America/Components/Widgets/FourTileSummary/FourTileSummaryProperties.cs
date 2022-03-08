using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace K2America.Components.Widgets
{
    public class FourTileSummaryProperties : IWidgetProperties
    {
        [EditingComponent(PathSelector.IDENTIFIER, Order = 0, Label = "Pages path", Tooltip = "select content path")]
        [EditingComponentProperty(nameof(PathSelectorProperties.RootPath), "/")]
        [Required(ErrorMessage = "You must need to select content path")]
        public IList<PathSelectorItem> ContentPath { get; set; }
        [EditingComponent(RichTextComponent.IDENTIFIER, Order = 1, Label = "Title")]
        [Required(ErrorMessage = "This field is required")]
        public string Title { get; set; }
    }
}
