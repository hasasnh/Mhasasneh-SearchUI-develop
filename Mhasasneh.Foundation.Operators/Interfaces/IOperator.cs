using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Linq.Expressions;
using Mhasasneh.Foundation.Common;

namespace Mhasasneh.Foundation.Operators.Interfaces
{
    public interface IOperator
    {
        string Identifier { get; }

        Expression<Func<SearchHit<SearchResultItem>, bool>> BuildCondition(SearchSettings settings, Expression<Func<SearchHit<SearchResultItem>, bool>> predicateBuilder);
    }
}
