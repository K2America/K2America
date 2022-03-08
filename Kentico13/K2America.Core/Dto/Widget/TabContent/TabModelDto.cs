using K2America.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2America.Core.Dto.Widget
{
   public class TabModelDto
    {
        public string Name { get; set; }
        public string NodeAliasPath { get; set; }
        public TabModelDto TabContent { get; set; }
        public List<TabContentItem> TabContentItems { get; set; }
    }
}
