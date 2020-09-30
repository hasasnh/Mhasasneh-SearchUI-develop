using System;
using TripleM.Feature.SearchUI.Services;
using System.Web.Mvc;
using Mhasasneh.Foundation.Core.Diagnostics;
using Mhasasneh.Foundation.Core.Diagnostics.Constants;
using TripleM.Feature.SearchUI.Base;
using TripleM.Feature.SearchUI.Models;
using TripleM.Feature.SearchUI.Models.SitecoreModels.Settings;
using Sitecore.ContentSearch.SearchTypes;
using Mhasasneh.Foundation.SitecoreAPI.SitecoreAPI.Interfaces;
using System.Linq;
using Sitecore.ContentSearch.Linq;
using System.Collections.Generic;
using Mhasasneh.Foundation.Cache.Interfaces;
using System.Web.Script.Serialization;

namespace TripleM.Feature.SearchUI.Controllers
{
    /// <inheritdoc />
    public class SearchUIController : BaseController
    {
        /// <summary>
        /// This Controller is used to receive the outside http post
        /// requests to insert objects in sitecore database based on 
        /// the type that is defined in the request uri
        /// </summary>

        private readonly ISearchService _searchService;

        private readonly INativeCache _nativeCache;

        /// <summary>
        ///  use native dependency injection
        /// </summary>
        /// <param name="manager"></param>
        public SearchUIController(ISearchService searchService, INativeCache nativeCache)
        {
            _searchService = searchService;
            _nativeCache = nativeCache;
        }

        /// <summary>
        /// View to Get the search ui component from the rendering parameters
        /// </summary>
        /// <returns>View with the search ui component as Model</returns>
        public ActionResult SearchUI(string search)
        {
            using (new LoggerSwitcher(LoggerConstants.FeatureSearchLoggerName))
            {
                try
                {
                    return View(GetResult(search));
                }
                catch (Exception ex)
                {
                    return GlobalError(ex);
                }

            }
        }

        /// <summary>
        /// View to Get the search ui component from the rendering parameters
        /// </summary>
        /// <returns>View with the search ui component as Model</returns>
        public string SearchUIAjax(string search)
        {
            using (new LoggerSwitcher(LoggerConstants.FeatureSearchLoggerName))
            {
                try
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(GetResult(search));
                }
                catch (Exception ex)
                {
                    return Newtonsoft.Json.JsonConvert.SerializeObject(ex.Message);
                }

            }
        }

        private SearchUIModel GetResult(string search)
        {
            var model = _mvcContext.GetDataSourceItem<SearchSettingsModel>();
            model.WordToSearch = search;
            _nativeCache.Delete("Highlight");
            IQueryable<SearchResultItem> result = _searchService.Search<SearchResultItem>("master", model);
            var serachResultUI = new SearchUIModel
            {
                SearchModel = model,
                SearchResultItems = result,
                SearchResultCount = result.Count(),
                Facets = _nativeCache.GetOrCreate<List<FacetCategory>>("Category", null),
                HighlightResult = _nativeCache.GetOrCreate<Dictionary<string, object>>("Highlight", null)
            };

            return serachResultUI;
        }
    }
}