using Microsoft.Extensions.DependencyInjection;
using Mhasasneh.Foundation.Core.Mvc.Interfaces;
using Mhasasneh.Foundation.Core.Mvc;

namespace Mhasasneh.Foundation.Mvc.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class MVCServicesConfigurator
    {
        //TODO: Here you can register the services
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterMVCServices(this IServiceCollection services) =>
             services.AddTransient<IMvcContext, MvcContext>();
    }
}
