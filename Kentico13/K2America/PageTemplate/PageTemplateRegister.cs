using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Register page templates
[assembly: RegisterPageTemplate("K2America.GenericContent", "Generic Content", customViewName: "PageTemplates/_GenericContent")]

namespace K2America.PageTemplate
{
    public class MarketTemplateFilter : IPageTemplateFilter
    {
        protected static string genericPageTemplateName = "K2America.GenericPage";

        public IEnumerable<PageTemplateDefinition> Filter(IEnumerable<PageTemplateDefinition> pageTemplates, PageTemplateFilterContext context)
        {
            // all page templates except generic page template
            return pageTemplates.Where(t => t.Identifier != genericPageTemplateName);
        }
    }
}