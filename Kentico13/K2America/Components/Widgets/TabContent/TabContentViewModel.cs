using K2America.Core.Dto.Widget;
using System.Collections.Generic;

namespace K2America.Components.Widgets
{
    public class TabContentViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<TabModelDto> Items { get; set; }
    }
}
