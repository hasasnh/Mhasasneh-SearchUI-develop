using Microsoft.Extensions.DependencyInjection;
using Mhasasneh.Foundation.Operators.Comparisons;
using Mhasasneh.Foundation.Operators.Interfaces;

namespace Mhasasneh.Foundation.Operators.Configuration
{
    /// <summary>
    /// This static class will be called at runtime to register services to the container 
    /// </summary>
    public static class OperatorsServicesConfigurator
    {
        //TODO: Here you can register the services
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection RegisterOperatorsServices(this IServiceCollection services) =>
             services.AddTransient<IComparisonBuilder, ComparisonBuilder>()
                     .AddTransient<IOperator, Equal>()
                     .AddTransient<IOperator, LessThan>()
                     .AddTransient<IOperator, LessTthanOrEqual>()
                     .AddTransient<IOperator, GreaterThanOrEqual>()
                     .AddTransient<IOperator, GreaterThan>();

    }
}
