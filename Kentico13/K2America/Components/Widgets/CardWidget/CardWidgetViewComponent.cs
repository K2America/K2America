using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterWidget(CardWidgetViewComponent.IDENTIFIER, typeof(CardWidgetViewComponent), "Card Widget", typeof(CardWidgetProperties), Description = "Displays the three tiles", IconClass = "icon-ribbon")]

namespace K2America.Components.Widgets
{
    public class CardWidgetViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.CardWidget";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="CardWidgetViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public CardWidgetViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(CardWidgetProperties properties)
        {
            CardWidgetViewModel model = new CardWidgetViewModel();
            //Fetching Tile Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetTileContentItems(properties.ContentPath[0].NodeAliasPath);
                model.Heading = properties.Heading;
            }
            return View("~/Components/Widgets/CardWidget/_CardWidgetView.cshtml", model);
        }
    }
}