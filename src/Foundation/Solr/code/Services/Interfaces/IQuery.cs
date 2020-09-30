using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Linq;
using System.Linq.Expressions;
using Mhasasneh.Foundation.Common;

namespace Mhasasneh.Foundation.Solr.Services.Interfaces
{
    public interface IQuery
    {
        Expression<Func<SearchResultItem, bool>> Query<T>(SearchSettings settings = null) where T : SearchResultItem;
        IQueryable<SearchResultItem> Query<T>(IQueryable<SearchResultItem> queryable, SearchSettings settings = null) where T : SearchResultItem;
    }
}
