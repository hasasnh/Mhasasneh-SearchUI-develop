using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch.SearchTypes;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Solr.Services.Interfaces;
using Sitecore.ContentSearch.Linq;

namespace Mhasasneh.Foundation.Solr.Services
{
    public class QueryBuilder : IQueryBuilder
    {
        private readonly IEnumerable<IQuery> _queries;
        public QueryBuilder(IEnumerable<IQuery> queries)
        {
            _queries = queries;
        }
        public Expression<Func<SearchResultItem, bool>> BuildQuery(SearchSettings settings = null)
        {
            Expression<Func<SearchResultItem, bool>> query = null;

            foreach (var q in _queries)
            {
                query = q.Query<SearchResultItem>(settings);
            }

            return query;
        }

        public IQueryable<SearchResultItem> BuildQuery(IQueryable<SearchResultItem> queryable, SearchSettings settings = null)
        {

            foreach (var q in _queries)
            {
                queryable = q.Query<SearchResultItem>(queryable,settings);
            }
            return queryable;
        }
    }
}
