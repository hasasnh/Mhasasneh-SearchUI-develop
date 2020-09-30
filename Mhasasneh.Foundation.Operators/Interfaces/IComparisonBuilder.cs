using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using System;
using Mhasasneh.Foundation.Common;
using System.Linq.Expressions;

namespace Mhasasneh.Foundation.Operators.Interfaces
{
    public interface IComparisonBuilder
    {
        Expression<Func<SearchHit<SearchResultItem>, bool>> Comparison(SearchSettings settings);
    }
}
