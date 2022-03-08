using K2America.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2America.Components.Widgets
{
    public class AccordionWidgetViewModel
    {
        public string Title { get; set; }
        public IEnumerable<Accordion> Items { get; set; }
    }
}
