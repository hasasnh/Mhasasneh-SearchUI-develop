using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Linq;
using System.Linq.Expressions;
using Mhasasneh.Foundation.Common;

namespace Mhasasneh.Foundation.Solr.Services.Interfaces
{
    public interface ISearchBuilder
    {
        Expression<Func<SearchResultItem, bool>> BuildQuery<T>(SearchSettings settings = null) where T : SearchResultItem;
        IQueryable<SearchResultItem> BuildQuery<T>(IQueryable<T> queryable, SearchSettings settings = null) where T : SearchResultItem;
        
    }
}
