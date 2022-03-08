using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterWidget(FourTileSummaryViewComponent.IDENTIFIER, typeof(FourTileSummaryViewComponent), "Four Tile Summary", typeof(FourTileSummaryProperties), Description = "Displays the four tiles", IconClass = "icon-ribbon")]

namespace K2America.Components.Widgets
{
    public class FourTileSummaryViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.FourTileSummary";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="FourTileSummaryViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public FourTileSummaryViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(FourTileSummaryProperties properties)
        {
            FourTileSummaryViewModel model = new FourTileSummaryViewModel();
            //Fetching Tile Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetTileContentItems(properties.ContentPath[0].NodeAliasPath);
                model.Title = properties.Title;
            }
            return View("~/Components/Widgets/FourTileSummary/_FourTileSummaryView.cshtml", model);
        }
    }
}