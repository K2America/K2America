using CMS.MediaLibrary;
using CMS.SiteProvider;
using K2America.Components.Widgets;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Linq;

[assembly: RegisterWidget(TextImageWithCTAViewComponent.IDENTIFIER, typeof(TextImageWithCTAViewComponent), "Text Image With CTA", typeof(TextImageWithCTAProperties), Description = "Displays the half width image with text and CTA.", IconClass = "icon-ribbon")]


namespace K2America.Components.Widgets
{
    public class TextImageWithCTAViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.TextImageWithCTA";
        private readonly IMediaFileInfoProvider mediaFileProvider;
        private readonly IMediaFileUrlRetriever fileUrlRetriever;


        /// <summary>
        /// Initializes a new instance of the <see cref="TextImageWithCTAViewComponent"/> class.
        /// </summary>
        /// <param name="mediaFileProvider">The media file provider.</param>
        /// <param name="fileUrlRetriever">The media file URL retriever.</param>
        public TextImageWithCTAViewComponent(IMediaFileInfoProvider mediaFileProvider, IMediaFileUrlRetriever fileUrlRetriever)
        {
            this.mediaFileProvider = mediaFileProvider;
            this.fileUrlRetriever = fileUrlRetriever;
        }

        //Fetching data from widget properties
        public ViewViewComponentResult Invoke(TextImageWithCTAProperties properties)
        {
            var imagePath = GetImagePath(properties);

            return View("~/Components/Widgets/TextImageWithCTA/_TextImageWithCTA.cshtml", new TextImageWithCTAViewModel
            {
                ImagePath = imagePath,
                Title = properties.Title,
                Description = properties.Description,
                ImageAltText = properties.ImageAltText,
                CTALink = properties.CTALink,
                CTAText = properties.CTAText
            });
        }

        //Get Relative path from Image Guid
        private string GetImagePath(TextImageWithCTAProperties properties)
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