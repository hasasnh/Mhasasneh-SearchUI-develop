using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Solr.Services.Interfaces;
using static Mhasasneh.Foundation.Common.Options.GetItemOptions;

namespace Mhasasneh.Foundation.Solr.Services.Queries
{
    public class RootQuery : IQuery
    {
        internal readonly ISitecoreService _sitecoreServices = DependencyResolver.Current.GetService<ISitecoreService>();

        public Expression<Func<SearchResultItem, bool>> WithRootOneLevel<T>(ID value) where T : SearchResultItem
        {
            var rootPredicates = PredicateBuilder.False<SearchResultItem>();
            rootPredicates = rootPredicates.Or(i => i.Parent == value);
            return rootPredicates;
        }

        public Expression<Func<SearchResultItem, bool>> Query<T>(SearchSettings settings = null) where T : SearchResultItem
        {
            var itemPath = _sitecoreServices.GetItemById(new GetItemByIdOptions { Id = Guid.Parse(settings.Scopes.FirstOrDefault()) }).Paths.FullPath;

            var rootPredicates = PredicateBuilder.False<SearchResultItem>();
            rootPredicates = rootPredicates.Or(i => i.Path.StartsWith(itemPath));
            return rootPredicates;
        }

        public IQueryable<SearchResultItem> Query<T>(IQueryable<SearchResultItem> queryable, SearchSettings settings = null) where T : SearchResultItem
        {
            return queryable.Where(Query<T>(settings));
        }

    }
}
