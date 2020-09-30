using System;

namespace Mhasasneh.Foundation.Cache
{
    public class NativeCache : Interfaces.INativeCache
    {
        System.Collections.Generic.Dictionary<string, object> _cache = new System.Collections.Generic.Dictionary<string, object>();

        public T GetOrCreate<T>(string key, T createItem)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = createItem;
            }

            var curentValue = (T)_cache[key];
            if (curentValue == null && _cache.ContainsKey(key) && createItem != null)
            {
                _cache.Remove(key);
                _cache[key] = createItem;
            }

            return (T)_cache[key];
        }

        public void Delete(string key)
        {
            if (_cache.ContainsKey(key))
            {
                _cache.Remove(key);
            }
        }
    }
}
