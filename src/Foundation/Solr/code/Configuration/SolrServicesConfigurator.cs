using Microsoft.Extensions.DependencyInjection;
using Mhasasneh.Foundation.Solr.Services;
using Mhasasneh.Foundation.Solr.Services.Interfaces;
using Mhasasneh.Foundation.Solr.Services.Queries;

namespace Mhasasneh.Foundation.Solr.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class SolrServicesConfigurator
    {
        //TODO: Here you can register the services
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterSolrServices(this IServiceCollection services) =>
             services.AddTransient<ISearchBuilder, SolrSearchBuilder>()
                     .AddTransient<IQueryBuilder, QueryBuilder>()
                     .AddTransient<IQuery, RootQuery>()
                     .AddTransient<IQuery, TemplateIDQuery>()
                     .AddTransient<IQuery, FacetQuery>()
                     .AddTransient<IQuery, MultiplePartialWordQuery>()
                     .AddTransient<IQuery, UnsupportedQuery>()
                     .AddTransient<IQuery, HighlightQuery>()
                     .AddTransient<IUnsupportedQuery, Date>()
                     .AddTransient<IUnsupportedQuery, Number>();
    }
}
