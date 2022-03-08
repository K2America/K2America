using K2America.Controllers;
using K2America.Core.Repositories;
using K2America.Models;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: RegisterPageRoute(ContactUs.CLASS_NAME, typeof(ContactUsController))]
namespace K2America.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsRepository _contactUsRepository;
        /// <summary>
        /// Creates an instance of <see cref="ServicesController"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }
        public IActionResult Index()
        {
            //Fetching Contact Us page Items  
            IEnumerable<ContactUs> Items = _contactUsRepository.GetContactUsItems();
            return View(Items);
        }
    }
}
