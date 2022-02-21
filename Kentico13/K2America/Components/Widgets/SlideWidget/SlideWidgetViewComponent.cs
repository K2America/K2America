using CMS.MediaLibrary;
using CMS.SiteProvider;
using K2America.Components.Widgets;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Linq;

[assembly: RegisterWidget(SlideWidgetViewComponent.IDENTIFIER, typeof(SlideWidgetViewComponent), "Slide Widget", typeof(SlideWidgetProperties), Description = "Displays the full width image and fifty fifty image slide.", IconClass = "icon-ribbon")]

namespace K2America.Components.Widgets
{
    public class SlideWidgetViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.SlideWidget";
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;


        /// <summary>
        /// Initializes a new instance of the <see cref="SlideWidgetViewComponent"/> class.
        /// </summary>
        /// <param name="mediaFileProvider">The media file provider.</param>
        /// <param name="fileUrlRetriever">The media file URL retriever.</param>
        public SlideWidgetViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        //Fetching data from widget properties
        public ViewViewComponentResult Invoke(SlideWidgetProperties properties)
        {
            var imagePath = GetImagePath(properties);

            return View("~/Components/Widgets/SlideWidget/_SlideWidget.cshtml", new SlideWidgetViewModel
            {
                ImagePath = imagePath,
                Title = properties.Title,
                LayoutType=properties.LayoutType,
                Description=properties.Description,
                ImageAltText=properties.ImageAltText,
                CTALink1 = properties.CTALink1,
                CTAText1 = properties.CTAText1,
                CTALink2 = properties.CTALink2,
                CTAText2 = properties.CTAText2
            });
        }

        //Get Relative path from Image Guid
        private string GetImagePath(SlideWidgetProperties properties)
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