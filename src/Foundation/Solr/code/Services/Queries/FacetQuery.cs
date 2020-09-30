using System;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Solr.Services.Interfaces;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Cache.Interfaces;
using System.Collections.Generic;

namespace Mhasasneh.Foundation.Solr.Services.Queries
{
    public class FacetQuery : IQuery
    {
        private readonly INativeCache _nativeCache;

        public FacetQuery(INativeCache nativeCache)
        {
            _nativeCache = nativeCache;
        }
        public IQueryable<SearchResultItem> Query<T>(IQueryable<SearchResultItem> queryable, SearchSettings settings = null) where T : SearchResultItem
        {
            if (settings.Facets == null) return queryable;
            foreach (var facet in settings.Facets)
            {
                queryable = queryable.FacetOn(x => x[facet], 1);
                _nativeCache.GetOrCreate<List<FacetCategory>>(facet, queryable.GetFacets().Categories);
            }
            return queryable;
        }

        public Expression<Func<SearchResultItem, bool>> Query<T>(SearchSettings settings = null) where T : SearchResultItem
        {
            throw new NotImplementedException();
        }
    }
}
