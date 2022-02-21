using K2America.Models;
using System.Collections.Generic;

namespace K2America.Components.Widgets
{
    public class MultipleTileViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<TileContent> Items { get; set; }
    }
}
