using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Core.Interfaces;

namespace Mhasasneh.Foundation.Core.BaseClasses
{
    public class WebSitecoreService : SitecoreService, IWebSitecoreService , ISitecoreService
    {
        public new readonly string Index = "sitecore_web_index";
        public WebSitecoreService() : base("web", "sitecore_web_index") { }
    }
}
