using K2America.Core.Repositories;
using K2America.Components.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

[assembly: RegisterWidget(AccordionWidgetViewComponent.IDENTIFIER, typeof(AccordionWidgetViewComponent), "Accordion Widget", typeof(AccordionWidgetProperties), Description = "Displays the multiple Accordions", IconClass = "icon-ribbon")]


namespace K2America.Components.Widgets
{
    public class AccordionWidgetViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "K2America.AccordionWidget";
        private readonly IPageTypeContentRepository _pageTypeContentRepository;
        /// <summary>
        /// Creates an instance of <see cref="AccordionWidgetViewComponent"/> class.
        /// </summary>
        /// <param name="pageTypeContentRepository">Repository for Page Type Content</param>
        public AccordionWidgetViewComponent(IPageTypeContentRepository pageTypeContentRepository)
        {
            _pageTypeContentRepository = pageTypeContentRepository;
        }
        /// <summary>
        /// Returns the model used by widgets' view.
        /// </summary>
        /// <param name="properties">Widget properties.</param>
        public IViewComponentResult Invoke(AccordionWidgetProperties properties)
        {
            AccordionWidgetViewModel model = new AccordionWidgetViewModel();
            //Fetching Accordion Content Items  
            if (properties != null && properties.ContentPath != null && properties.ContentPath.Count > 0)
            {
                model.Items = _pageTypeContentRepository.GetAccordionItems(properties.ContentPath[0].NodeAliasPath);
                model.Title = properties.Title;
            }
            return View("~/Components/Widgets/AccordionWidget/_AccordionWidgetView.cshtml", model);
        }
    }
}