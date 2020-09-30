using System.Collections.Generic;

namespace Mhasasneh.Foundation.Core.Reflections.Interfaces
{
    public interface IAttributeService
    {
        T Handel<T>(KeyValuePair<string, string> attribute, T obj) where T : IReflectionBase, new();
    }
}
