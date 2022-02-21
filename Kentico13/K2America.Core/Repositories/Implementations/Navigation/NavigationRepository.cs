using CMS.DocumentEngine;
using K2America.Core.Dto;
using K2America.Models;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2America.Core.Repositories
{
   public class NavigationRepository :INavigationRepository
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
        public NavigationRepository(IPageRetriever pageRetriever, RepositoryCacheHelper repositoryCacheHelper, IPageUrlRetriever pageUrlRetriever)
        {
            this.pageRetriever = pageRetriever;
            this.pageUrlRetriever = pageUrlRetriever;
            this.repositoryCacheHelper = repositoryCacheHelper;
        }


        /// <summary>
        /// Returns an enumerable collection of footer menu items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<TreeNode> List</returns>
        public IEnumerable<TreeNode> GetFooterMenuItems()
        {
            return pageRetriever.Retrieve<TreeNode>(
                query => query
                    .FilterDuplicates()
                    .Path("/Site-Navigation/Footer", PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder")
                    .MenuItems()
                   ,
                cache => cache
                    .Key($"{nameof(NavigationRepository)}|{nameof(GetFooterMenuItems)}")
                    // Include path dependency to flush cache when a new child page is created or page order is changed.
                    .Dependencies((_, builder) => { }, true));
        }
        /// <summary>
        /// Returns an enumerable collection of social media items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<SocialMedia> List</returns>
        public IEnumerable<SocialMedia> GetSocialMediaItems()
        {
            return pageRetriever.Retrieve<SocialMedia>(
                query => query
                    .FilterDuplicates()
                    .Path("/Site-Navigation/Social-Media", PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder"),
                cache => cache
                    .Key($"{nameof(NavigationRepository)}|{nameof(GetSocialMediaItems)}")
                    // Include path dependency to flush cache when a new child page is created or page order is changed.
                    .Dependencies((_, builder) => { }, true));
        }
        /// <summary>
        /// Returns an enumerable collection of header menu items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<HeaderMenuDto> List</returns>
        public IEnumerable<HeaderMenuDto> GetHeaderMenuItem()
        {
            List<HeaderMenuDto> result = new List<HeaderMenuDto>();
            var data = pageRetriever.Retrieve<CustomFolder>(
                query => query
                    .Path("/Site-Navigation/Header", PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                 ,
                cache => cache
                    .Key($"{nameof(NavigationRepository)}|{nameof(GetHeaderMenuItem)}|{"/Site-Navigation/Header"}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath("/Site-Navigation/Header", PathTypeEnum.Children)))
                .Select(m => new HeaderMenuDto()
                {
                    Name = m.Name,
                    Icon= m.Icon1,
                    NodeAliasPath = m.NodeAliasPath
                }).ToList();

            if (data != null && data.Any())
            {
                for (int i = 0; i < data.Count; i++)
                {
                    HeaderMenuDto headerMenuDto = new HeaderMenuDto();
                    headerMenuDto.HeaderMenuItems = data[i];
                    headerMenuDto.MenuItems = GetMenuItems(data[i].NodeAliasPath);
                    result.Add(headerMenuDto);
                }
            }

            return result;
        }
        /// <summary>
        /// Returns an enumerable collection of header menu items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<TreeNode> List</returns>
        private List<TreeNode> GetMenuItems(string nodeAliasPath)
        {
            return pageRetriever.Retrieve<TreeNode>(
                query => query
                    .FilterDuplicates()
                    .Path(nodeAliasPath, PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder")
                    .MenuItems(),
                cache => cache
                    .Key($"{nameof(NavigationRepository)}|{nameof(GetMenuItems)}")
                    // Include path dependency to flush cache when a new child page is created or page order is changed.
                    .Dependencies((_, builder) => { }, true)).ToList();
        }
        /// <summary>
        /// Returns an enumerable collection of main menu items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<TreeNode> List</returns>
        public IEnumerable<TreeNode> GetMainMenuItems()
        {
            return pageRetriever.Retrieve<TreeNode>(
                query => query
                    .FilterDuplicates()
                     .Where("NodeLevel=1")
                    .OrderByAscending("NodeLevel", "NodeOrder")
                    .MenuItems()
                   ,
                cache => cache
                    .Key($"{nameof(NavigationRepository)}|{nameof(GetMainMenuItems)}")
                    // Include path dependency to flush cache when a new child page is created or page order is changed.
                    .Dependencies((_, builder) => { }, true));
        }
    }
}
