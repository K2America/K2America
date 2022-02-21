using K2America.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2America.Components.Widgets
{
    public class CardWidgetViewModel
    {
        public string Heading { get; set; }
        public IEnumerable<TileContent> Items { get; set; }
    }
}
