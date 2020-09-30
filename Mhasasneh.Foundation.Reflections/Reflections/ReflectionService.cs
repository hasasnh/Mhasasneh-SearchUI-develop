using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mhasasneh.Foundation.Core.Attributes;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;

namespace Mhasasneh.Foundation.Core.Reflections
{
    public class ReflectionService : IReflectionService
    {
        private readonly IEnumerable<IChildren> _childrens;
        private readonly IEnumerable<ICommaSeparated> _commaSeparatedList;

        public ReflectionService(IEnumerable<IChildren> childrens, IEnumerable<ICommaSeparated> commaSeparatedList)
        {
            _childrens = childrens;
            _commaSeparatedList = commaSeparatedList;
        }

        public Dictionary<string, string> GetAllAttribute<T>(Type type = null) where T : IReflectionBase
        {
            PropertyInfo[] propertyInfos;
            Type cType;

            if (type == null)
            {
                // Get the properties of 'Type' class object.
                propertyInfos = typeof(T).GetProperties();
                cType = typeof(T);
            }
            else
            {
                // Get the properties of 'Type' class object.
                propertyInfos = type.GetProperties();
                cType = type;
            }

            Dictionary<string, string> attributeList = new Dictionary<string, string>();

            foreach (var prop in propertyInfos)
            {
                var customAttributes = cType.GetProperty(prop.Name).GetCustomAttributes(typeof(IAttributeBase), false);
                if (customAttributes.Count() <= 0) break;
                var attrHandlerName = (((IAttributeBase)customAttributes.First()).Name);

                if (prop.PropertyType.GetInterface(nameof(IReflectionBase)) != null)
                {
                    attributeList.Add(prop.PropertyType.AssemblyQualifiedName, attrHandlerName);
                }
                else
                {
                    attributeList.Add(prop.Name, attrHandlerName);
                }
            }
            return attributeList;
        }

        public T InvokeGenericMethod<T>(string spacename, string assembly, string genericMethodName, object[] param) where T : IReflectionBase
        {
            var type = Type.GetType(string.Format("{0},{1}", spacename, assembly));
            object instance = Activator.CreateInstance(type);

            MethodInfo toInvoke = type.GetMethod(genericMethodName);
            var method = toInvoke.MakeGenericMethod(typeof(T));
            return (T)method.Invoke(instance, param);
        }

        public IReflectionBase FillChildrens(string key, List<string> childrens, IReflectionBase obj)
        {
            foreach (var children in _childrens)
            {
                if (key == children.Key) return children.Fill(childrens, obj);
            }
            return null;
        }

        public IReflectionBase FillChildrens(string key, Dictionary<string, string> childrens, IReflectionBase obj)
        {
            foreach (var children in _childrens)
            {
                if (key == children.Key) return children.Fill(childrens, obj);
            }
            return null;
        }

        public IReflectionBase FillCommaSeparated(List<string> value, IReflectionBase obj, string key)
        {
            foreach (var commaSeparated in _commaSeparatedList)
            {
                if (commaSeparated.Key == key)
                {
                    obj = commaSeparated.Fill(value, obj);
                }
            }
            return obj;
        }
    }
}
