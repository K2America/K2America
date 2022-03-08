using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace K2America.Helpers
{
    public static class DataParserHelper
    {
        public static string GenerateSectionID(string inputValue)
        {
            string parsedInput = string.Empty;
            if (!string.IsNullOrEmpty(inputValue))
            {
                var sectionId = Regex.Replace(inputValue, "[^a-zA-Z0-9_]+", " ");
                parsedInput = string.Format("sec_{0}", sectionId.Replace(" ", "").Trim().ToLower());
            }
            return parsedInput;
        }
    }
}
