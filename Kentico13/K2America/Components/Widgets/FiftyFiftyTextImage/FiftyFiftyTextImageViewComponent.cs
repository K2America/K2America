using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using CMS.MediaLibrary;
using Kentico.Content.Web.Mvc;
using System.Linq;
using System;
using CMS.SiteProvider;

[assembly: RegisterWidget(FiftyFiftyTextImageViewComponent.IDENTIFIER, typeof(FiftyFiftyTextImageViewComponent), "Fifty Fifty Text Image Widget", typeof(FiftyFiftyTextImageProperties), Description = "Displays the Fifty Fifty Text and Image", IconClass = "icon-ribbon")]


namespace K2America.Components.Widgets
{
    public class FiftyFiftyTextImageViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.FiftyFiftyTextImage";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;
        /// <summary>
        /// Creates an instance of <see cref="FiftyFiftyTextImageViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        /// <param name="mediaFileProvider">The media file provider.</param>
        /// <param name="fileUrlRetriever">The media file URL retriever.</param>
        public FiftyFiftyTextImageViewComponent(IPageTypeContentRepository pageTypeContentRepository, IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(FiftyFiftyTextImageProperties properties)
        {
            //Get Image path
            var imagePath = GetImagePath(properties);
            FiftyFiftyTextImageViewModel model = new FiftyFiftyTextImageViewModel();
            //Fetching Tile Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetRawContentItems(properties.ContentPath[0].NodeAliasPath);
                model.ImagePath = imagePath;
                model.ImageAltText = properties.ImageAltText;
               
            }
            return View("~/Components/Widgets/FiftyFiftyTextImage/_FiftyFiftyTextImageView.cshtml", model);
        }
        //Get Relative path from Image Guid
        private string GetImagePath(FiftyFiftyTextImageProperties properties)
        {
            var imageGuid = properties.Image.FirstOrDefault()?.FileGuid ?? Guid.Empty;
            if (imageGuid == Guid.Empty)
            {
                return null;
            }

            var image = mediaFileProvider.Get(imageGuid, SiteContext.CurrentSiteID);
            if (image == null)
            {
                return string.Empty;
            }

            return fileUrlRetriever.Retrieve(image).RelativePath;
        }
    }
}