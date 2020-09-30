using Microsoft.Extensions.DependencyInjection;
using TripleM.Feature.SearchUI.Configuration;
using Mhasasneh.Foundation.Core.Configuration;
using Mhasasneh.Foundation.Core.Extensions;
using Sitecore.DependencyInjection;
using Mhasasneh.Foundation.Solr.Configuration;
using Mhasasneh.Foundation.Common.Configuration;
using Mhasasneh.Foundation.Algorithms.Configuration;
using Mhasasneh.Foundation.SitecoreAPI.Configuration;
using Mhasasneh.Foundation.Operators.Configuration;
using Mhasasneh.Foundation.Context.Configuration;
using Mhasasneh.Foundation.Mvc.Configuration;

namespace TripleM.Web.Configuration
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvcControllers("TripleM.Feature.*");
            MVCServicesConfigurator.RegisterMVCServices(serviceCollection);
            ContextServicesConfigurator.RegisterContextServices(serviceCollection);
            CacheServicesConfigurator.RegisterCacheServices(serviceCollection);
            SitecoreAPIServicesConfigurator.RegisterSitecoreAPIServices(serviceCollection);
            OperatorsServicesConfigurator.RegisterOperatorsServices(serviceCollection);
            AlgorithmServicesConfigurator.RegisterAlgorithmServices(serviceCollection);
            SearchUIServicesConfigurator.RegisterMigrationServices(serviceCollection);
            DiagnosticsServicesConfigurator.RegisterDiagnosticsServices(serviceCollection);
            SolrServicesConfigurator.RegisterSolrServices(serviceCollection);
            ReflectionsServicesConfigurator.RegisterReflectionsServices(serviceCollection);
            CoreServicesConfigurator.RegisterCoreServices(serviceCollection);
            CommonServicesConfigurator.RegisterCommonServices(serviceCollection);
        }
    }
}