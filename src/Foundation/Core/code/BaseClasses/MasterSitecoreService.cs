using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Core.Interfaces;

namespace Mhasasneh.Foundation.Core.BaseClasses
{
    public class MasterSitecoreService : SitecoreService, IMasterSitecoreService, ISitecoreService
    {
        public new readonly string Index = "sitecore_master_index";

        public MasterSitecoreService() : base("master", "sitecore_master_index")
        {

        }
    }
}
