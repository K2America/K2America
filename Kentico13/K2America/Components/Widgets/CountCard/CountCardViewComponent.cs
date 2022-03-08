using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Linq;

[assembly: RegisterWidget(CountCardViewComponent.IDENTIFIER, typeof(CountCardViewComponent), "Count Card", typeof(CountCardProperties), Description = "Displays the count of total project we developed global customers etc.", IconClass = "icon-ribbon")]

namespace K2America.Components.Widgets
{
    public class CountCardViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.CountCard";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="CountCardViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public CountCardViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(CountCardProperties properties)
        {
            CountCardViewModel model = new CountCardViewModel();
            //Fetching Count Card Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetCountCardItems(properties.ContentPath[0].NodeAliasPath);
                model.Title = properties.Title;
                model.Description = properties.Description;
            }
            return View("~/Components/Widgets/CountCard/_CountCardView.cshtml", model);
        }
    }
}
