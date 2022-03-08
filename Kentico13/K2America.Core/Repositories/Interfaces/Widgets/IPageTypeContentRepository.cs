using K2America.Core.Dto.Widget;
using K2America.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K2America.Core.Repositories
{
   public interface IPageTypeContentRepository
    {
        IEnumerable<ClientContent>GetClientContentItems(string contentPath);
        IEnumerable<TileContent> GetTileContentItems(string contentPath);
        IEnumerable<RawItemContent> GetRawContentItems(string contentPath);
        IEnumerable<Article> GetArticleContentItems(string contentPath);
        IEnumerable<Accordion> GetAccordionItems(string contentPath);
        IEnumerable<CountCardContent> GetCountCardItems(string contentPath);
        IEnumerable<TabModelDto> GetTabContentItems(string contentPath);
        IEnumerable<Technology> GetTechnologyItems(string contentPath);
        ServicesDto GetServicesContentItems(string contentPath, int page);
    }
}
