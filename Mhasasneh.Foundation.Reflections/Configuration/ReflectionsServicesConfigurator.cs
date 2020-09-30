using Mhasasneh.Foundation.Core.Reflections;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace Mhasasneh.Foundation.Mvc.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class ReflectionsServicesConfigurator
    {
        //TODO: Here you can register the services
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterReflectionsServices(this IServiceCollection services) =>
             services.AddTransient<IReflectionService, ReflectionService>()
                     .AddTransient<IChildren, FacetsChildren>()
                     .AddTransient<IChildren, QueriesChildren>()
                     .AddTransient<ICommaSeparated, EnabledCommaSeparated>()
                     .AddTransient<ICommaSeparated, ValueCommaSeparated>();
    }
}
