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
    }
}
