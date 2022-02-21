using K2America.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2America.Components.Widgets
{
    public class FiftyFiftyTextImageViewModel
    {
        public string ImagePath { get; set; }
        public string ImageAltText { get; set; }
        public IEnumerable<RawItemContent> Items { get; set; }
    }
}
