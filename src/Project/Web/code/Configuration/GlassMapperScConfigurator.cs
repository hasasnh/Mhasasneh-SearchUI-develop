using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;
using Glass.Mapper.Sc.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using System.Collections.Concurrent;

namespace TripleM.Web.Configuration
{
    public class GlassMapperScConfigurator : IServicesConfigurator
    {
        static ConcurrentDictionary<string, ISitecoreService> _sitecoreServices = new ConcurrentDictionary<string, ISitecoreService>();
        private static ISitecoreService GetService(string databaseName)
        {
            return _sitecoreServices.GetOrAdd(databaseName, name => new SitecoreService(name));
        }

        private static ISitecoreService GetRequestService()
        {
            var name = Sitecore.Context.Database.Name;
            return GetService(name);
        }

        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(ISitecoreService), provider => GetService("master"));
            serviceCollection.AddScoped(typeof(IMvcContext), provider =>
            {
                var service = GetRequestService();
                return new MvcContext(service);
            });
            serviceCollection.AddScoped(typeof(IRequestContext), provider =>
            {
                var service = GetRequestService();
                return new RequestContext(service);
            });
        }
    }
}