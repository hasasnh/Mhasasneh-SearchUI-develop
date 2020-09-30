using System;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Operators.Interfaces;
using Mhasasneh.Foundation.Solr.Services.Interfaces;
using Sitecore.ContentSearch.Linq.Utilities;

namespace Mhasasneh.Foundation.Solr.Services.Queries
{
    public class Date : IUnsupportedQuery
    {
        private readonly IComparisonBuilder _comparisonBuilder;
        private readonly string templateID = "{DE0AB6D7-F8D9-46A1-B8BC-BBF18FC74882}";
        public Date(IComparisonBuilder comparisonBuilder)
        {
            _comparisonBuilder = comparisonBuilder;
        }

        public Expression<Func<SearchHit<SearchResultItem>, bool>> Query<T>(IQueryable<SearchResultItem> queryable, SearchSettings settings = null) where T : SearchResultItem
        {
            if (settings.Queries.Where(i => i.Key == templateID).Count() > 0)
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
