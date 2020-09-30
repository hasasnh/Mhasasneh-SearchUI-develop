using Microsoft.Extensions.DependencyInjection;
using Mhasasneh.Foundation.Common.Interfaces;

namespace Mhasasneh.Foundation.Common.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class CommonServicesConfigurator
    {
        //TODO: Here you can register the services
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterCommonServices(this IServiceCollection services) =>
             services.AddTransient<ISitecoreService, SitecoreService>();
    }
}
