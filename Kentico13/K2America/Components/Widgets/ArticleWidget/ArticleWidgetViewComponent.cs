using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterWidget(ArticleWidgetViewComponent.IDENTIFIER, typeof(ArticleWidgetViewComponent), "Article Widget", typeof(ArticleWidgetProperties), Description = "Displays the three tile with CTA", IconClass = "icon-ribbon")]

namespace K2America.Components.Widgets
{
    public class ArticleWidgetViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.ArticleWidget";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="ArticleWidgetViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public ArticleWidgetViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(ArticleWidgetProperties properties)
        {
            ArticleWidgetViewModel model = new ArticleWidgetViewModel();
            //Fetching Article Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetArticleContentItems(properties.ContentPath[0].NodeAliasPath);
                model.Title = properties.Title;
                model.Description = properties.Description;
            }
            return View("~/Components/Widgets/ArticleWidget/_ArticleWidgetView.cshtml", model);
        }
    }
}