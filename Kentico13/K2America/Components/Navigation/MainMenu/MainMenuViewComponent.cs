using CMS.DocumentEngine;
using K2America.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace K2America.Components.Navigation
{
    public class MainMenuViewComponent : ViewComponent
    {

        private readonly INavigationRepository _navigationRepository;
        /// <summary>
        /// Creates an instance of <see cref="FooterViewComponent"/> class.
        /// </summary>
        /// <param name="navigationRepository">Repository for Navigation</param>
        public MainMenuViewComponent(INavigationRepository navigationRepository)
        {
            _navigationRepository = navigationRepository;
        }
        public IViewComponentResult Invoke()
        {
            //Fetching footer menu items  
            IEnumerable<TreeNode> mainMenuItems = _navigationRepository.GetMainMenuItems();

            return View("~/Components/Navigation/MainMenu/_MainMenu.cshtml", mainMenuItems);
        }
    }
}