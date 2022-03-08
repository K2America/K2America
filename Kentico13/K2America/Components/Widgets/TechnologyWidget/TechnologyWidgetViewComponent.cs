using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterWidget(TechnologyWidgetViewComponent.IDENTIFIER, typeof(TechnologyWidgetViewComponent), "Technology Widget", typeof(TechnologyWidgetProperties), Description = "Displays the Technology Content", IconClass = "icon-ribbon")]


namespace K2America.Components.Widgets
{
    public class TechnologyWidgetViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.TechnologyWidget";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="TechnologyWidgetViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public TechnologyWidgetViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(TechnologyWidgetProperties properties)
        {
            TechnologyWidgetViewModel model = new TechnologyWidgetViewModel();
            //Fetching Technology Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetTechnologyItems(properties.ContentPath[0].NodeAliasPath);
                model.Title = properties.Title;
            }
            return View("~/Components/Widgets/TechnologyWidget/_TechnologyWidgetView.cshtml", model);
        }
    }
}