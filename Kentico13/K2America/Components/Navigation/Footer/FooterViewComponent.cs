using CMS.DocumentEngine;
using K2America.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace K2America.Components.Navigation
{
    public class FooterViewComponent : ViewComponent
    {
     
        private readonly INavigationRepository _navigationRepository;
        /// <summary>
        /// Creates an instance of <see cref="FooterViewComponent"/> class.
        /// </summary>
        /// <param name="navigationRepository">Repository for Navigation</param>
        public FooterViewComponent(INavigationRepository navigationRepository)
        {
            _navigationRepository = navigationRepository;
        }
        public IViewComponentResult Invoke()
        {
         //Fetching footer menu items  
            IEnumerable<TreeNode> footerMenuItems = _navigationRepository.GetFooterMenuItems();
            
            return View("~/Components/Navigation/Footer/_Footer.cshtml", footerMenuItems);
        }
    }
}