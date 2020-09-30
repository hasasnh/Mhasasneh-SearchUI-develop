using System.Collections.Generic;
using System.Threading.Tasks;
using Mhasasneh.Foundation.SitecoreAPI.SitecoreAPI.Interfaces;
using TripleM.Feature.SearchUI.Providers.Base;

namespace TripleM.Feature.SearchUI.Providers
{
    internal class SolrSearchProvider : BaseSearchUIProvider, ISearchProvider
    {
        public string Type => throw new System.NotImplementedException();

        public bool Enabled => throw new System.NotImplementedException();

        public Task ExecuteAsync()
        {
            throw new System.NotImplementedException();
        }

        internal override void SaveMigratedDataToSitecore<T>(List<T> migrationDtosList)
        {
            throw new System.NotImplementedException();
        }
    }
}