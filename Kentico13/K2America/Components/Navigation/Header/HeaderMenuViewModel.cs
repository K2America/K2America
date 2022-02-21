using K2America.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2America.Components.Navigation
{
    public class HeaderMenuViewModel
    {
        public IEnumerable<HeaderMenuDto> Items { get; set; }
    }
}
