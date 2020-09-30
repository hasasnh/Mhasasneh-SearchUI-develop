using Microsoft.Extensions.DependencyInjection;
using Mhasasneh.Foundation.SitecoreAPI.SitecoreAPI.Interfaces;
using TripleM.Feature.SearchUI.Providers;
using TripleM.Feature.SearchUI.Services;

namespace TripleM.Feature.SearchUI.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class SearchUIServicesConfigurator
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterMigrationServices(this IServiceCollection services) =>
             services.AddScoped<ISearchProvider, SolrSearchProvider>()
            .AddScoped<ISearchUIService, SearchUIService>();
    }
}
