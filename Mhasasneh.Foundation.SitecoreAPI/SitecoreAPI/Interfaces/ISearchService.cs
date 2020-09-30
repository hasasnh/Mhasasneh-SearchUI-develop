using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System.Collections.Generic;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;
using System.Linq;

namespace Mhasasneh.Foundation.SitecoreAPI.SitecoreAPI.Interfaces
{
    public interface ISearchService
    {
        /// <summary>
        /// Get index based on the database
        /// </summary>
        /// <param name="database">sitecore database</param>
        /// <returns>search index</returns>
        ISearchIndex GetIndex(string database);

        /// <summary>
        /// Get the search result for specific model
        /// </summary>
        /// <typeparam name="T">Index model</typeparam>
        /// <returns>Search result as list</returns>
        IEnumerable<T> SearchAny<T>(string database = "master") where T : class;

        IEnumerable<SearchResultItem> Search<T>(string database = "master") where T : SearchResultItem;

        IQueryable<SearchResultItem> Search<T>(string database = "master", IReflectionBase settings = null) where T : SearchResultItem;


    }
}
