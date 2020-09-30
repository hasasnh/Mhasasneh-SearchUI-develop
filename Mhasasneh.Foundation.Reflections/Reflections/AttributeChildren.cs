using Sitecore.Data;
using Sitecore.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Common.Options;
using Mhasasneh.Foundation.Core.Attributes;
using Mhasasneh.Foundation.Core.Context.Interfaces;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;

namespace Mhasasneh.Foundation.Core.Reflections
{
    public class AttributeChildren : IAttributeService, IAttributeChildren
    {
        private readonly ReflectionService _reflectionService;
        private readonly ISitecoreService _sitecoreService;
        private readonly ICustomContext _customContext;
        public AttributeChildren()
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
                var filedName = (((IAttributeBase)typeof(T).GetProperty(attribute.Key).GetCustomAttributes(typeof(IAttributeBase), false).First()).Param);
                var parentTemplateID = (((IAttributeBase)typeof(T).GetProperty(attribute.Key).GetCustomAttributes(typeof(IAttributeBase), false).First()).ParentTemplateID);
                var childrenTemplateID = (((IAttributeBase)typeof(T).GetProperty(attribute.Key).GetCustomAttributes(typeof(IAttributeBase), false).First()).ChildrenTemplateID);
                var items = parentItem.GetChildren().Where(i => i.TemplateID == ID.Parse(parentTemplateID)).FirstOrDefault();
                if (items == null)
                {
                    return obj;
                }
                else
                {
                    var levelTwo = !string.IsNullOrEmpty(childrenTemplateID) ? items.GetChildren().Where(i => i.TemplateID == ID.Parse(childrenTemplateID)) : items.GetChildren();

                    if (items.Name != "Facets")
                    {
                        Dictionary<string, string> list = new Dictionary<string, string>();
                        foreach (var item in levelTwo)
                        {
                            list.Add(item.TemplateID.ToString(), item.Fields[filedName].Value);
                        }
                        return (T)_reflectionService.FillChildrens(attribute.Key, list, obj);
                    }
                    else
                    {
                        return (T)_reflectionService.FillChildrens(attribute.Key, levelTwo.Select(i => i.Fields[filedName].Value).ToList(), obj);
                    }
                }
            }
            return obj;
        }
    }
}
