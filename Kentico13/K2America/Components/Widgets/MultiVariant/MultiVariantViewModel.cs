using K2America.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2America.Components.Widgets
{
    public class MultiVariantViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public IEnumerable<TileContent> Items { get; set; }
    }
}
