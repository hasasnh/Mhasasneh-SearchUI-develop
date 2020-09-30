using Microsoft.Extensions.DependencyInjection;
using Mhasasneh.Foundation.Core.Context;
using Mhasasneh.Foundation.Core.Context.Interfaces;


namespace Mhasasneh.Foundation.Context.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class ContextServicesConfigurator
    {
        //TODO: Here you can register the services
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterContextServices(this IServiceCollection services) =>
             services.AddTransient<ICustomContext, CustomContext>();
    }
}
