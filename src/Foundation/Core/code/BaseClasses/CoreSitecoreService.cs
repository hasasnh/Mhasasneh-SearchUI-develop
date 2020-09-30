using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Core.Interfaces;

namespace Mhasasneh.Foundation.Core.BaseClasses
{
    public class CoreSitecoreService : SitecoreService, ICoreSitecoreService, ISitecoreService
    {
        public new readonly string Index = "sitecore_core_index";

        public CoreSitecoreService() : base("core", "sitecore_core_index") { }
    }
}
