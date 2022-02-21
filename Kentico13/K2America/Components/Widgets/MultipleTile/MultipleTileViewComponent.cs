using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Linq;

[assembly: RegisterWidget(MultipleTileViewComponent.IDENTIFIER, typeof(MultipleTileViewComponent), "Multiple Tile Widget", typeof(MultipleTileProperties), Description = "Displays the different size of tile with CTA", IconClass = "icon-ribbon")]

namespace K2America.Components.Widgets
{
    public class MultipleTileViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.MultipleTile";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="MultipleTileViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public MultipleTileViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(MultipleTileProperties properties)
        {
            MultipleTileViewModel model = new MultipleTileViewModel();
            //Fetching Tile Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetTileContentItems(properties.ContentPath[0].NodeAliasPath);
                model.Title = properties.Title;
                model.Description = properties.Description;
            }
            return View("~/Components/Widgets/MultipleTile/_MultipleTileView.cshtml", model);
        }
    }
}