using Microsoft.Extensions.DependencyInjection;
using Mhasasneh.Foundation.Algorithms.Search.String.Interfaces;
using Mhasasneh.Foundation.Solr.Algorithms.Search.String;

namespace Mhasasneh.Foundation.Algorithms.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class AlgorithmServicesConfigurator
    {
        //TODO: Here you can register the services
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterAlgorithmServices(this IServiceCollection services) =>
             services.AddTransient<ISearchAlgorithm, BinarySearch>();
    }
}
