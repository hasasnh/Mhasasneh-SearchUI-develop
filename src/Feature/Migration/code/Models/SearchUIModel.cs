using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using System.Collections.Generic;
using TripleM.Feature.SearchUI.Models.SitecoreModels.Settings;

namespace TripleM.Feature.SearchUI.Models
{
    public class SearchUIModel
    {
        public SearchSettingsModel SearchModel { get; set; }

        public IEnumerable<SearchResultItem> SearchResultItems { get; set; }

        public int SearchResultCount { get; set; }

        public List<FacetCategory> Facets { get; set; }

        public Dictionary<string, object> HighlightResult { get; set; }
    }
}