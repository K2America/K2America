using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterWidget(MultiVariantViewComponent.IDENTIFIER, typeof(MultiVariantViewComponent), "Multi Varient Widget", typeof(MultiVariantProperties), Description = "Displays the three different background tiles with CTA and key words ", IconClass = "icon-ribbon")]


namespace K2America.Components.Widgets
{
    public class MultiVariantViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.MultiVarient";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="MultiVariantViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public MultiVariantViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(MultiVariantProperties properties)
        {
            MultiVariantViewModel model = new MultiVariantViewModel();
            //Fetching Tile Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetTileContentItems(properties.ContentPath[0].NodeAliasPath);
                model.Title = properties.Title;
                model.Description = properties.Description;
                model.KeyWords = properties.KeyWords;
            }
            return View("~/Components/Widgets/MultiVariant/_MultiVariantView.cshtml", model);
        }
    }
}