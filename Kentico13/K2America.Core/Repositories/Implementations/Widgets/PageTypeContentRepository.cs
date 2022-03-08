using CMS.DocumentEngine;
using K2America.Core.Dto.Widget;
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
        /// <returns>IEnumerable<Article> List</returns>
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
        /// <summary>
        /// Returns an enumerable collection of Accordion content items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<Accordion> List</returns>
        public IEnumerable<Accordion> GetAccordionItems(string contentPath)
        {
            return pageRetriever.Retrieve<Accordion>(
                query => query
                    .FilterDuplicates()
                    .Path(contentPath, PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder"),
                cache => cache
                   .Key($"{nameof(PageTypeContentRepository)}|{nameof(GetAccordionItems)}|{contentPath}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath(contentPath, PathTypeEnum.Children)));
        }
        /// <summary>
        /// Returns an enumerable collection of Count Card content items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<CountCardContent> List</returns>
        public IEnumerable<CountCardContent> GetCountCardItems(string contentPath)
        {
            return pageRetriever.Retrieve<CountCardContent>(
                query => query
                    .FilterDuplicates()
                    .Path(contentPath, PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder"),
                cache => cache
                   .Key($"{nameof(PageTypeContentRepository)}|{nameof(GetCountCardItems)}|{contentPath}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath(contentPath, PathTypeEnum.Children)));
        }
        /// <summary>
        /// Returns an enumerable collection of Technology content items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<Technology> List</returns>
        public IEnumerable<Technology> GetTechnologyItems(string contentPath)
        {
            return pageRetriever.Retrieve<Technology>(
                query => query
                    .FilterDuplicates()
                    .Path(contentPath, PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder"),
                cache => cache
                   .Key($"{nameof(PageTypeContentRepository)}|{nameof(GetTechnologyItems)}|{contentPath}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath(contentPath, PathTypeEnum.Children)));
        }
        /// <summary>
        /// Returns an enumerable collection of Tab content items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<TabModelDto> List</returns>
        public IEnumerable<TabModelDto> GetTabContentItems(string contentPath)
        {
            List<TabModelDto> result = new List<TabModelDto>();
            var data = pageRetriever.Retrieve<CustomFolder>(
                query => query
                    .Path(contentPath, PathTypeEnum.Children)
                    .OrderBy("NodeOrder")
                 ,
                cache => cache
                    .Key($"{nameof(NavigationRepository)}|{nameof(GetTabContentItems)}|{contentPath}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath(contentPath, PathTypeEnum.Children)))
                .Select(m => new TabModelDto()
                {
                    Name = m.Name,
                    NodeAliasPath = m.NodeAliasPath
                }).ToList();

            if (data != null && data.Any())
            {
                for (int i = 0; i < data.Count; i++)
                {
                    TabModelDto tabModelDto = new TabModelDto();
                    tabModelDto.TabContent = data[i];
                    tabModelDto.TabContentItems = GetTabContent(data[i].NodeAliasPath);
                    result.Add(tabModelDto);
                }
            }

            return result;
        }
        /// <summary>
        /// Returns an enumerable collection of Tab Content items ordered by the content tree order and level.
        /// </summary>
        /// <returns>IEnumerable<TabContentItem> List</returns>
        private List<TabContentItem> GetTabContent(string nodeAliasPath)
        {
            return pageRetriever.Retrieve<TabContentItem>(
                query => query
                    .FilterDuplicates()
                    .Path(nodeAliasPath, PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder"),
                cache => cache
                    .Key($"{nameof(NavigationRepository)}|{nameof(GetTabContent)}")
                    // Include path dependency to flush cache when a new child page is created or page order is changed.
                    .Dependencies((_, builder) => { }, true)).ToList();
        }


        public ServicesDto GetServicesContentItems(string contentPath, int page)
        {
            var pagesize = 6;
            List<ServicesContentDto> result = new List<ServicesContentDto>();
            var data = pageRetriever.Retrieve<TileContent>(
                query => query
                    .FilterDuplicates()
                    .Path(contentPath, PathTypeEnum.Children)
                    .OrderByAscending("NodeLevel", "NodeOrder"),
                cache => cache
                   .Key($"{nameof(PageTypeContentRepository)}|{nameof(GetTechnologyItems)}|{contentPath}")
                    // Include path dependency to flush cache when a new child page is created.
                    .Dependencies((_, builder) => builder.PagePath(contentPath, PathTypeEnum.Children)));
            //Document in sepcific category

            if (page == 1)
            {

                result = data.Take(pagesize).Select(m => new ServicesContentDto()
                {
                    Title = m.Title,
                    Image = m.Image,
                    ImageAltText = m.ImageAltText,
                    Description = m.Description
                }).ToList();
            }
            else
            {
                result = data.Select(m => new ServicesContentDto()
                {
                    Title = m.Title,
                    Image = m.Image,
                    ImageAltText = m.ImageAltText,
                    Description = m.Description

                }).Skip((page - 1) * pagesize).Take(pagesize).ToList();
            }
           
                    ServicesDto servicesWidgetDto = new ServicesDto();
                    servicesWidgetDto.ServicesContent = result;
                    servicesWidgetDto.HasMorePages = data.Skip(page * pagesize).Any();
              
            return servicesWidgetDto;
        }
    }
}
