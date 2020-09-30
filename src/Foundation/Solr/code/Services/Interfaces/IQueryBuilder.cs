using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Linq;
using System.Linq.Expressions;
using Mhasasneh.Foundation.Common;

namespace Mhasasneh.Foundation.Solr.Services.Interfaces
{
    public interface IQueryBuilder
    {
        Expression<Func<SearchResultItem, bool>> BuildQuery(SearchSettings settings = null);

        IQueryable<SearchResultItem> BuildQuery(IQueryable<SearchResultItem> queryable,SearchSettings settings = null);
        
    }
}
