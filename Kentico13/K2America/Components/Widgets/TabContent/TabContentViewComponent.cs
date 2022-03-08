using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterWidget(TabContentViewComponent.IDENTIFIER, typeof(TabContentViewComponent), "Tab Content Widget", typeof(TabContentProperties), Description = "Displays the Tab Content woth key Points", IconClass = "icon-ribbon")]


namespace K2America.Components.Widgets
{
    public class TabContentViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.TabContent";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="TabContentViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public TabContentViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(TabContentProperties properties)
        {
            TabContentViewModel model = new TabContentViewModel();
            //Fetching Tab Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetTabContentItems(properties.ContentPath[0].NodeAliasPath);
                model.Title = properties.Title;
                model.Description = properties.Description;
            }
            return View("~/Components/Widgets/TabContent/_TabContentView.cshtml", model);
        }
    }
}