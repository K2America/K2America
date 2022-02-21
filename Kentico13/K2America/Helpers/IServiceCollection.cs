using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using K2America.Core;
using K2America.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace K2America.Helpers
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDIServices(this IServiceCollection services)
        {
            AddRepositories(services);

            services.AddSingleton<RepositoryCacheHelper>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            //Add repository scope here as per below example
            services.AddSingleton<INavigationRepository,NavigationRepository>();
            services.AddSingleton<IPageTypeContentRepository, PageTypeContentRepository>();
        }
    }
}