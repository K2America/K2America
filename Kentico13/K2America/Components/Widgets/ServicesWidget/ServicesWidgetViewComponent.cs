using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterWidget(ServicesWidgetViewComponent.IDENTIFIER, typeof(ServicesWidgetViewComponent), "Services Widget", typeof(ServicesWidgetProperties), Description = "Displays the multiple services tiles", IconClass = "icon-ribbon")]

namespace K2America.Components.Widgets
{
    public class ServicesWidgetViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.ServicesWidget";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="ServicesWidgetViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public ServicesWidgetViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(ServicesWidgetProperties properties)
        {
            int page = 1;
            ServicesWidgetViewModel model = new ServicesWidgetViewModel();
            //Fetching Tile Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetServicesContentItems(properties.ContentPath[0].NodeAliasPath, page);
                model.Title = properties.Title;
                model.Description = properties.Description;
                model.ContentPath = properties.ContentPath[0].NodeAliasPath;
            }
            return View("~/Components/Widgets/ServicesWidget/_ServicesWidgetView.cshtml", model);
        }
    }
}