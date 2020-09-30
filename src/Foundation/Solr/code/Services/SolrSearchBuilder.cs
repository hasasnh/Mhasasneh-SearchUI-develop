using System;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch.SearchTypes;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Solr.Services.Interfaces;

namespace Mhasasneh.Foundation.Solr.Services
{
    public class SolrSearchBuilder : ISearchBuilder
    {
        private readonly IQueryBuilder _builder;
        public SolrSearchBuilder(IQueryBuilder builder)
        {
            _builder = builder;
        }
        public Expression<Func<SearchResultItem, bool>> BuildQuery<T>(SearchSettings settings = null) where T : SearchResultItem
        {
            return _builder.BuildQuery(settings);
        }

        public IQueryable<SearchResultItem> BuildQuery<T>(IQueryable<T> queryable, SearchSettings settings = null) where T : SearchResultItem
        {
            return _builder.BuildQuery(queryable, settings);
        }
    }
}
