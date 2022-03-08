using K2America.Core.Dto.Widget;
using K2America.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2America.Components.Widgets
{
    public class ServicesWidgetViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContentPath { get; set; }
        public ServicesDto Items { get; set; }
    }
}
