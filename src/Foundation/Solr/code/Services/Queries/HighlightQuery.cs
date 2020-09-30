using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mhasasneh.Foundation.Cache.Interfaces;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Solr.Services.Interfaces;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;

namespace Mhasasneh.Foundation.Solr.Services.Queries
{
    public class HighlightQuery : IQuery
    {

        private readonly INativeCache _nativeCache;

        public HighlightQuery(INativeCache nativeCache)
        {
            _nativeCache = nativeCache;
        }
        public Expression<Func<SearchResultItem, bool>> Query<T>(SearchSettings settings = null) where T : SearchResultItem
        {
            throw new NotImplementedException();
        }

        public IQueryable<SearchResultItem> Query<T>(IQueryable<SearchResultItem> queryable, SearchSettings settings = null) where T : SearchResultItem
        {
            if (settings.Enabled == null) return queryable;
            if (string.IsNullOrEmpty(settings.WordToSearch)
                || string.IsNullOrWhiteSpace(settings.WordToSearch)
                || settings.Enabled.FirstOrDefault().ToLower() == "false")
                return queryable;

            Dictionary<string, object> Fields = new Dictionary<string, object>();

            foreach (var q in queryable)
            {
                foreach (var f in q.Fields)
                {
                    if (f.Key != "_content" && f.Key != "content" && f.Value.ToString().Contains(settings.WordToSearch))
                    {
                        var newValue = f.Value.ToString().Replace(settings.WordToSearch, string.Format("{0}{1}{2}", "<span style=\"background-color: #FFFF00\">", settings.WordToSearch, "</span>"));
                        if (!Fields.ContainsKey(f.Key))
                        {
                            Fields.Add(f.Key, newValue);
                        }
                    }
                }
            }

            _nativeCache.GetOrCreate<Dictionary<string, object>>("Highlight", Fields);
            return queryable;
        }
    }
}
