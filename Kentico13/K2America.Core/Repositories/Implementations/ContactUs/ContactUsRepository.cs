using CMS.DocumentEngine;
using K2America.Models;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace K2America.Core.Repositories
{
   public class ContactUsRepository : IContactUsRepository
    {
        private readonly IPageRetriever pageRetriever;
        private readonly IPageUrlRetriever pageUrlRetriever;
        private readonly RepositoryCacheHelper repositoryCacheHelper;


        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationRepository"/> class.
        /// </summary>
        /// <param name="pageRetriever">The page retriever.</param>
        /// <param name="pageUrlRetriever">The page Url retriever.</param>
        /// <param name="repositoryCacheHelper">Handles caching of retrieved objects.</param>
        public ContactUsRepository(IPageRetriever pageRetriever, RepositoryCacheHelper repositoryCacheHelper, IPageUrlRetriever pageUrlRetriever)
        {
            this.pageRetriever = pageRetriever;
            this.pageUrlRetriever = pageUrlRetriever;
            this.repositoryCacheHelper = repositoryCacheHelper;
        }
        /// <summary>
        /// Returns an enumerable collection of contact-us page items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<ContactUs> List</returns>
        public IEnumerable<ContactUs> GetContactUsItems()
        {
            return pageRetriever.Retrieve<ContactUs>(
                query => query
                    .FilterDuplicates()
                    .Path("/Contact-Us", PathTypeEnum.Explicit)
                    .OrderByAscending("NodeLevel", "NodeOrder") ,
                cache => cache
               .Key($"{nameof(ContactUsRepository)}|{nameof(GetContactUsItems)}|{"/Contact-Us"}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath("/Contact-Us", PathTypeEnum.Children)));
        }
    }
}
