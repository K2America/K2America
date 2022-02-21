using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Linq;

[assembly: RegisterWidget(OurClientViewComponent.IDENTIFIER, typeof(OurClientViewComponent), "Our Client", typeof(OurClientProperties), Description = "Displays the our client logo and client name", IconClass = "icon-ribbon")]

namespace K2America.Components.Widgets
{
    public class OurClientViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.OurClient";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="OurClientViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public OurClientViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(OurClientProperties properties)
        {
            OurClientViewModel model = new OurClientViewModel();
            //Fetching Client Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetClientContentItems(properties.ContentPath[0].NodeAliasPath);
                model.Title = properties.Title;
                model.Description = properties.Description;
            }
            return View("~/Components/Widgets/OurClient/_OurClientView.cshtml", model);
        }
    }
}