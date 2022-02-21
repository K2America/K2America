using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterWidget(ThreeTileViewComponent.IDENTIFIER, typeof(ThreeTileViewComponent), "Three Tile Widget", typeof(ThreeTileProperties), Description = "Displays the three tile with CTA", IconClass = "icon-ribbon")]

namespace K2America.Components.Widgets
{
    public class ThreeTileViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.ThreeTile";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="ThreeTileViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public ThreeTileViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(ThreeTileProperties properties)
        {
            ThreeTileViewModel model = new ThreeTileViewModel();
            //Fetching Tile Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetTileContentItems(properties.ContentPath[0].NodeAliasPath);
                model.Title = properties.Title;
                model.Description = properties.Description;
            }
            return View("~/Components/Widgets/ThreeTile/_ThreeTileView.cshtml", model);
        }
    }
}