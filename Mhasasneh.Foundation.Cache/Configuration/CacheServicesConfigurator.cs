using Microsoft.Extensions.DependencyInjection;

namespace Mhasasneh.Foundation.Common.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class CacheServicesConfigurator
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterCacheServices(this IServiceCollection services) =>
              services.AddSingleton<Cache.Interfaces.INativeCache, Cache.NativeCache>();
    }
}
