using Mhasasneh.Foundation.Core.Diagnostics.interfaces;
using Mhasasneh.Foundation.Core.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TripleM.Feature.SearchUI.Providers.Base
{
    /// <summary>
    /// Base class provider that share the shared IOC services, and supporting abstract pattern
    /// </summary>
    public abstract class BaseSearchUIProvider
    {
        internal readonly IMasterSitecoreService _sitecoreService =
            DependencyResolver.Current.GetService<IMasterSitecoreService>();
        internal readonly ILogger _logger =
            DependencyResolver.Current.GetService<ILogger>();

        /// <summary>
        /// Abstract method to handle saving of the migrations items to sitecore
        /// </summary>
        /// <typeparam name="T">type of Dtos class</typeparam>
        /// <param name="migrationDtosList">list of Dtos migration model</param>
        internal abstract void SaveMigratedDataToSitecore<T>(List<T> migrationDtosList) where T : class;

    }
}