using CMS.DocumentEngine;
using K2America.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2America.Core.Dto
{
   public class HeaderMenuDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string NodeAliasPath { get; set; }
        public HeaderMenuDto HeaderMenuItems { get; set; }
        public List<TreeNode> MenuItems { get; set; }
    }
}
