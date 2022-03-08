using K2America.Components.Widgets;
using K2America.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K2America.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="ServicesController"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public ServicesController(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        public IActionResult GetServices(int page,string contentPath)
        {
            ServicesWidgetViewModel model = new ServicesWidgetViewModel();
            //Fetching Tile Content Items  
            model.Items = _pageTypeContentRepository.GetServicesContentItems(contentPath, page);
            return Json(model);
        }
    }
}
