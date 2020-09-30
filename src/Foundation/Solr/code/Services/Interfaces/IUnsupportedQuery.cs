using Mhasasneh.Foundation.Common;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mhasasneh.Foundation.Solr.Services.Interfaces
{
    public interface IUnsupportedQuery
    {
        Expression<Func<SearchHit<SearchResultItem>, bool>> Query<T>(IQueryable<SearchResultItem> queryable, SearchSettings settings = null) where T : SearchResultItem;
    }
}
