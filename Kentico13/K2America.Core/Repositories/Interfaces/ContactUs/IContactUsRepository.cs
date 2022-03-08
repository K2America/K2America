using CMS.DocumentEngine;
using K2America.Core.Dto;
using K2America.Models;
using System.Collections.Generic;

namespace K2America.Core.Repositories
{
   public interface IContactUsRepository
    {
        IEnumerable<ContactUs> GetContactUsItems();
    }
}
