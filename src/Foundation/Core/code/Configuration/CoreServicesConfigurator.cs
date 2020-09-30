using Microsoft.Extensions.DependencyInjection;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Core.BaseClasses;
using Mhasasneh.Foundation.Core.Interfaces;


namespace Mhasasneh.Foundation.Core.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class CoreServicesConfigurator
    {
        //TODO: Here you can register the services
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterCoreServices(this IServiceCollection services) =>
             services.AddTransient<ISitecoreService, SitecoreService>()
                     .AddSingleton<ICoreSitecoreService, CoreSitecoreService>()
                     .AddSingleton<IMasterSitecoreService, MasterSitecoreService>()
                     .AddSingleton<IWebSitecoreService, WebSitecoreService>()
                     .AddSingleton<ISitecoreService, CoreSitecoreService>()
                     .AddSingleton<ISitecoreService, MasterSitecoreService>()
                     .AddSingleton<ISitecoreService, WebSitecoreService>();
    }
}
