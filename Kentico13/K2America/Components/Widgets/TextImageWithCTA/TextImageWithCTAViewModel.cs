using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2America.Components.Widgets
{
    public class TextImageWithCTAViewModel
    {
        public string ImagePath { get; set; }
        public string BackgroundColor { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageAltText { get; set; }
        public string CTAText { get; set; }
        public string CTALink { get; set; }
    }
}
