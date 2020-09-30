using System;

namespace Mhasasneh.Foundation.Cache.Interfaces
{
    public interface INativeCache
    {
        T GetOrCreate<T>(string key, T createItem);
        void Delete(string key);
    }
}
