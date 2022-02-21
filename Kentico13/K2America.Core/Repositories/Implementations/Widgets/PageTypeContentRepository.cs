using CMS.DocumentEngine;
using K2America.Models;
using Kentico.Content.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace K2America.Core.Repositories
{
   public class PageTypeContentRepository : IPageTypeContentRepository
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
        public PageTypeContentRepository(IPageRetriever pageRetriever, RepositoryCacheHelper repositoryCacheHelper, IPageUrlRetriever pageUrlRetriever)
        {
            this.pageRetriever = pageRetriever;
            this.pageUrlRetriever = pageUrlRetriever;
            this.repositoryCacheHelper = repositoryCacheHelper;
        }


        /// <summary>
        /// Returns an enumerable collection of client content items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<ClientContent> List</returns>
        public IEnumerable<ClientContent> GetClientContentItems(string contentPath)
        {
            return pageRetriever.Retrieve<ClientContent>(
                query => query
                    .FilterDuplicates()
                    .Path(contentPath, PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder"),
                cache => cache
                        .Key($"{nameof(PageTypeContentRepository)}|{nameof(GetClientContentItems)}|{contentPath}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath(contentPath, PathTypeEnum.Children)));
        }
        /// <summary>
        /// Returns an enumerable collection of tile content items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<TileContent> List</returns>
        public IEnumerable<TileContent> GetTileContentItems(string contentPath)
        {
            return pageRetriever.Retrieve<TileContent>(
                query => query
                    .FilterDuplicates()
                    .Path(contentPath, PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder"),
                cache => cache
                   .Key($"{nameof(PageTypeContentRepository)}|{nameof(GetTileContentItems)}|{contentPath}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath(contentPath, PathTypeEnum.Children)));
        }
        /// <summary>
        /// Returns an enumerable collection of raw content items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<RawItemContent> List</returns>
        public IEnumerable<RawItemContent> GetRawContentItems(string contentPath)
        {
            return pageRetriever.Retrieve<RawItemContent>(
                query => query
                    .FilterDuplicates()
                    .Path(contentPath, PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder"),
                cache => cache
                   .Key($"{nameof(PageTypeContentRepository)}|{nameof(GetRawContentItems)}|{contentPath}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath(contentPath, PathTypeEnum.Children)));
        }
        /// <summary>
        /// Returns an enumerable collection of Article content items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<RawItemContent> List</returns>
        public IEnumerable<Article> GetArticleContentItems(string contentPath)
        {
            return pageRetriever.Retrieve<Article>(
                query => query
                    .FilterDuplicates()
                    .Path(contentPath, PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder"),
                cache => cache
                   .Key($"{nameof(PageTypeContentRepository)}|{nameof(GetArticleContentItems)}|{contentPath}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath(contentPath, PathTypeEnum.Children)));
        }
    }
}
