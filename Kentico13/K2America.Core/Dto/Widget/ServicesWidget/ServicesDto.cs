using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2America.Core.Dto.Widget
{
   public class ServicesDto
    {
        public List<ServicesContentDto> ServicesContent { get; set; }
        public bool HasMorePages { get; set; }
    }
}
