using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using System;
using System.Collections.Generic;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;
using Mhasasneh.Foundation.SitecoreAPI.SitecoreAPI.Interfaces;
using Mhasasneh.Foundation.Solr.Services.Interfaces;
using System.Linq;

namespace Mhasasneh.Foundation.SitecoreAPI.SitecoreAPI
{
    public class SearchService : ISearchService
    {
        private const string defaultDatabase = "master";

        private const string defaultIndex = "sitecore_master_index";

        private readonly IEnumerable<ISitecoreService> _sitecoreServices;

        private readonly ISearchBuilder _searchBuilder;


        public SearchService(IEnumerable<ISitecoreService> sitecoreServices, ISearchBuilder searchBuilder)
        {
            _sitecoreServices = sitecoreServices;
            _searchBuilder = searchBuilder;
        }

        /// <summary>
        /// Get index based on the database
        /// </summary>
        /// <param name="database">sitecore database</param>
        /// <returns>search index</returns>
        public ISearchIndex GetIndex(string database)
        {

            foreach (var service in _sitecoreServices)
            {
                if (service.DatabaseName != null)
                {
                    if (service.DatabaseName.Equals(database, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return ContentSearchManager.GetIndex(service.Index);
                    }
                }
            }

            return ContentSearchManager.GetIndex(defaultIndex);
        }


        /// <summary>
        /// Get the search result for specific model
        /// </summary>
        /// <typeparam name="T">Index model</typeparam>
        /// <param name="database">database</param>
        /// <param name="settings">search settings</param>
        /// <returns>Search result as list</returns>
        public IQueryable<SearchResultItem> Search<T>(string database = defaultDatabase, IReflectionBase settings = null) where T : SearchResultItem
        {
            using (IProviderSearchContext context = GetIndex(database).CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return _searchBuilder.BuildQuery(context.GetQueryable<T>(), new SearchSettings() { Enabled = settings.Enabled, Value = settings.Value, Facets = settings.Facets, Scopes = settings.Scopes, Queries = settings.Queries, WordToSearch = settings.WordToSearch });
            }
        }

        public IEnumerable<SearchResultItem> Search<T>(string database = "master") where T : SearchResultItem
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> SearchAny<T>(string database = "master") where T : class
        {
            throw new NotImplementedException();
        }

    }
}
