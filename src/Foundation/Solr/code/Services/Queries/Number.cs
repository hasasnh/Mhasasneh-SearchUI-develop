using System;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Operators.Interfaces;
using Mhasasneh.Foundation.Solr.Services.Interfaces;
namespace Mhasasneh.Foundation.Solr.Services.Queries
{
    public class Number : IUnsupportedQuery
    {
        private readonly IComparisonBuilder _comparisonBuilder;
        private readonly string templateID = "{0DBE8A42-D852-4FF0-B28E-68E2CDF4541D}";
        public Number(IComparisonBuilder comparisonBuilder)
        {
            _comparisonBuilder = comparisonBuilder;
        }

        public Expression<Func<SearchHit<SearchResultItem>, bool>> Query<T>(IQueryable<SearchResultItem> queryable, SearchSettings settings = null) where T : SearchResultItem
        {

            if (settings?.Queries.Where(i => i.Key == templateID)?.Count() > 0)
            {
                settings.TemplateID = templateID;
                return _comparisonBuilder.Comparison(settings);
            }
            else
            {
                return null;
            }
        }

    }
}
