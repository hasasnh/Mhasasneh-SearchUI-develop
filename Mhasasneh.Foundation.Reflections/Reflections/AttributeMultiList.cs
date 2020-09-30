using Sitecore.Data;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Common.Options;
using Mhasasneh.Foundation.Core.Context.Interfaces;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;
using Mhasasneh.Foundation.Core.Attributes;

namespace Mhasasneh.Foundation.Core.Reflections
{
    public class AttributeMultiList : IAttributeService, IAttributeChildren
    {
        private readonly ReflectionService _reflectionService;
        private readonly ISitecoreService _sitecoreService;
        private readonly ICustomContext _customContext;
        public AttributeMultiList()
        {
            _reflectionService = (ReflectionService)ServiceLocator.ServiceProvider.GetService(typeof(IReflectionService));
            _sitecoreService = (ISitecoreService)ServiceLocator.ServiceProvider.GetService(typeof(ISitecoreService));
            _customContext = (ICustomContext)ServiceLocator.ServiceProvider.GetService(typeof(ICustomContext));
        }

        public T Handel<T>(KeyValuePair<string, string> attribute, T obj) where T : IReflectionBase, new()
        {
            if (Type.GetType(attribute.Key)?.GetInterface(nameof(IReflectionBase)) != null)
            {
                var type = Type.GetType(attribute.Key);
                var attr = _reflectionService.GetAllAttribute<IReflectionBase>(type);
            }
            else
            {

                var parentItem = _sitecoreService.GetItemById(new GetItemOptions.GetItemByIdOptions { Id = Guid.Parse(_customContext.CurrentDatasourceId) });
                var templateID = (((IAttributeBase)typeof(T).GetProperty(attribute.Key).GetCustomAttributes(typeof(IAttributeBase), false).First()).Param);
                var item = parentItem.GetChildren().Where(i => i.TemplateID == ID.Parse(templateID)).FirstOrDefault();
                if (item == null)
                {
                    return obj;
                }
                else
                {
                    obj.Scopes = ((Sitecore.Data.Fields.MultilistField)item.Fields[attribute.Key]).List.ToList();
                    return obj;
                }
            }
            return obj;
        }
    }
}
