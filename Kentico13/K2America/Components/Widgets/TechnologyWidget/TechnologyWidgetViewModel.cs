using K2America.Models;
using System.Collections.Generic;

namespace K2America.Components.Widgets
{
    public class TechnologyWidgetViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Technology> Items { get; set; }
    }
}
