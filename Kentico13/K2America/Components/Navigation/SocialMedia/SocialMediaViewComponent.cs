using K2America.Core.Repositories;
using K2America.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace K2America.Components.Navigation
{
    public class SocialMediaViewComponent : ViewComponent
    {

        private readonly INavigationRepository _navigationRepository;
        /// <summary>
        /// Creates an instance of <see cref="SocialMediaViewComponent"/> class.
        /// </summary>
        /// <param name="navigationRepository">Repository for Navigation</param>
        public SocialMediaViewComponent(INavigationRepository navigationRepository)
        {
            _navigationRepository = navigationRepository;
        }
        public IViewComponentResult Invoke(bool homeView)
        {
            //Filter social media view for home and generic pages.
            var viewName = homeView ? "_SocialMediaHome" : "_SocialMedia";
            //Fetching SocialMedia items  
            IEnumerable<SocialMedia> SocialMediaMenuItems = _navigationRepository.GetSocialMediaItems();

            return View($"~/Components/Navigation/SocialMedia/{viewName}.cshtml", SocialMediaMenuItems);
        }
    }
}