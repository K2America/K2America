using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace K2America.Components.Widgets
{
    public class FiftyFiftyTextImageProperties : IWidgetProperties
    {
        [EditingComponent(PathSelector.IDENTIFIER, Order = 0, Label = "Pages path", Tooltip = "select content path")]
        [EditingComponentProperty(nameof(PathSelectorProperties.RootPath), "/")]
        [Required(ErrorMessage = "You must need to select content path")]
        public IList<PathSelectorItem> ContentPath { get; set; }
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Order = 1, Label = "Image")]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        public IEnumerable<MediaFilesSelectorItem> Image { get; set; } = Enumerable.Empty<MediaFilesSelectorItem>();
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Image Alternative Text")]
        public string ImageAltText { get; set; }
    }
}
