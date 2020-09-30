using Microsoft.Extensions.DependencyInjection;
using Mhasasneh.Foundation.SitecoreAPI.SitecoreAPI;
using Mhasasneh.Foundation.SitecoreAPI.SitecoreAPI.Interfaces;

namespace Mhasasneh.Foundation.SitecoreAPI.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class SitecoreAPIServicesConfigurator
    {
        //TODO: Here you can register the services
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterSitecoreAPIServices(this IServiceCollection services) =>
             services.AddTransient<ISearchService, SearchService>();
    }
}
