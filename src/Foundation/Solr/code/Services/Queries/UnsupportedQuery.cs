using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Solr.Services.Interfaces;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mhasasneh.Foundation.Solr.Services.Queries
{
    class UnsupportedQuery : IQuery
    {
        private readonly IEnumerable<IUnsupportedQuery> _unsupportedQueryList;

        public UnsupportedQuery(IEnumerable<IUnsupportedQuery> unsupportedQueryList)
        {
            _unsupportedQueryList = unsupportedQueryList;
        }
        public Expression<Func<SearchResultItem, bool>> Query<T>(SearchSettings settings = null) where T : SearchResultItem
        {
            throw new NotImplementedException();
        }

        public IQueryable<SearchResultItem> Query<T>(IQueryable<SearchResultItem> queryable, SearchSettings settings = null) where T : SearchResultItem
        {
            if (settings.Queries == null) return queryable;

            var rootPredicates = PredicateBuilder.False<SearchHit<SearchResultItem>>();
            foreach (var _unsupportedQuery in _unsupportedQueryList)
            {
                var pred = _unsupportedQuery.Query<T>(queryable, settings);
                if (pred != null)
                {
                    rootPredicates = rootPredicates.Or(pred);
                }
            }

            if (rootPredicates.ToString() == "param => False") return queryable;
            return queryable.GetResults().Hits.Where(rootPredicates.Compile()).Select(d => d.Document).AsQueryable();
        }
    }
}
