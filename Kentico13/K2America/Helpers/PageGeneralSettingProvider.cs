using CMS.DocumentEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2America.Helpers
{
    public static class PageGeneralSettingProvider
    {
        /// <summary>
        /// Fetching Generic Setting for site layout
        /// </summary>
        /// <returns></returns>
        public static TreeNode GetSettngs()
        {

            var genericSettings = DocumentHelper.GetDocument("K2America", "/Generic-Settings", "en-US", false, "K2America.GenericSettings", null, null, TreeProvider.ALL_LEVELS, false, null, null);

            return genericSettings;

        }
    }
}
