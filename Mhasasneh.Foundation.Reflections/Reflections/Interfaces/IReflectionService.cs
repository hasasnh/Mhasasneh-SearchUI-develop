using System;
using System.Collections.Generic;

namespace Mhasasneh.Foundation.Core.Reflections.Interfaces
{
    public interface IReflectionService
    {
        Dictionary<string, string> GetAllAttribute<T>(Type type = null) where T : IReflectionBase;

        T InvokeGenericMethod<T>(string spacename, string assembly, string genericMethodName, object[] param) where T : IReflectionBase;

        IReflectionBase FillChildrens(string key, List<string> childrens, IReflectionBase obj);
        IReflectionBase FillCommaSeparated(List<string> value, IReflectionBase obj, string key);
    }
}
