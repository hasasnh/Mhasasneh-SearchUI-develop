using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Solr.Services.Interfaces;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mhasasneh.Foundation.Solr.Services.Queries
{
    public class MultiplePartialWordQuery : IQuery
    {
        public Expression<Func<SearchResultItem, bool>> Query<T>(SearchSettings settings = null) where T : SearchResultItem
        {
            var querySplitted = settings.WordToSearch?.Split(' ');

            var rootPredicates = PredicateBuilder.True<SearchResultItem>();

            if (querySplitted == null) return rootPredicates;

            foreach (var query in querySplitted)
            {
                rootPredicates = rootPredicates.And(item => item.Content.Contains(query));
            }
            return rootPredicates;
        }

        public IQueryable<SearchResultItem> Query<T>(IQueryable<SearchResultItem> queryable, SearchSettings settings = null) where T : SearchResultItem
        {
            return queryable.Where(Query<T>(settings));
        }
    }
}
