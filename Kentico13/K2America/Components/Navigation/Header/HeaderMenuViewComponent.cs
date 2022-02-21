using K2America.Core.Repositories;
using K2America.Models;
using Kentico.Content.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace K2America.Components.Navigation
{
    public class HeaderMenuViewComponent : ViewComponent
    {

        private readonly INavigationRepository _navigationRepository;
        /// <summary>
        /// Creates an instance of <see cref="HeaderMenuViewComponent"/> class.
        /// </summary>
        /// <param name="navigationRepository">Repository for Navigation</param>
        public HeaderMenuViewComponent(INavigationRepository navigationRepository)
        {
            _navigationRepository = navigationRepository;
        }
        public IViewComponentResult Invoke(bool homeView)
        {
            //Filter header menu view for home and generic pages.
            var viewName = homeView ? "_HeaderMenuHome" : "_HeaderMenu";
            //Fetching Header menu items  
            HeaderMenuViewModel model = new HeaderMenuViewModel();
            model.Items = _navigationRepository.GetHeaderMenuItem();
            return View($"~/Components/Navigation/Header/{viewName}.cshtml", model);
        }
    }
}