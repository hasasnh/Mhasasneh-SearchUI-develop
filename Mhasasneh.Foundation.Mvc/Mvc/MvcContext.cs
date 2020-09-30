using Sitecore.Data.Items;
using System;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Common.Options;
using Mhasasneh.Foundation.Core.Context.Interfaces;
using Mhasasneh.Foundation.Core.Mvc.Interfaces;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;

namespace Mhasasneh.Foundation.Core.Mvc
{
    public class MvcContext : IMvcContext
    {
        private readonly IReflectionService _reflectionService;
        private readonly ICustomContext _customContext;


        public MvcContext(ISitecoreService sitecoreService, IReflectionService reflectionService, ICustomContext customContext)
        {
            SitecoreService = sitecoreService;
            _reflectionService = reflectionService;
            _customContext = customContext;
        }


        public ISitecoreService SitecoreService { get; }

        public T GetDataSourceItem<T>() where T : IReflectionBase, new()
        {
            var allAttr = _reflectionService.GetAllAttribute<T>();
            var obj = new T() ;
            foreach (var attr in allAttr)
            {
                obj = _reflectionService.InvokeGenericMethod<T>(allAttr[attr.Key], "Mhasasneh.Foundation.Reflections", "Handel", new object[] { attr, obj });
            }

            return obj;
        }

        public Item GetDataSourceSitecoreItem<T>() where T : class
        {
            return SitecoreService.GetItemById<T>(new GetItemOptions.GetItemByIdOptions { Id = Guid.Parse(_customContext.CurrentDatasourceId) });
        }
    }
}
