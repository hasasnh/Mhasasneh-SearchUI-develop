using System;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Solr.Services.Interfaces;

namespace Mhasasneh.Foundation.Solr.Services.Queries
{
    public class TemplateIDQuery : IQuery
    {
        private readonly string templateID = "{966D4814-211A-4FC5-8C25-A4DC8D287F5B}";
        public Expression<Func<SearchResultItem, bool>> Query<T>(SearchSettings settings = null) where T : SearchResultItem
        {
            var templateID = ID.Parse(settings.Queries.Where(x => x.Key == this.templateID).FirstOrDefault().Value);

            var rootPredicates = PredicateBuilder.False<SearchResultItem>();
            rootPredicates = rootPredicates.Or(i => i.TemplateId == templateID);
            return rootPredicates;
        }

        public IQueryable<SearchResultItem> Query<T>(IQueryable<SearchResultItem> queryable, SearchSettings settings = null) where T : SearchResultItem
        {
            if(settings.Queries ==null) return queryable;
            if (settings?.Queries.Where(i => i.Key == templateID)?.Count() > 0)
            {
                return queryable.Where(Query<T>(settings));
            }
            else
            {
                return queryable;
            }
        }
    }
}
