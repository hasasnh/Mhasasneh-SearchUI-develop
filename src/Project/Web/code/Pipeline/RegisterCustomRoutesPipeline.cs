using Sitecore.Mvc.Pipelines.Loader;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using TripleM.Web.App_Start;

namespace TripleM.Web.Pipeline
{
    public class RegisterCustomRoutesPipeline : InitializeRoutes
    {
        public override void Process(PipelineArgs args)
        {
            //recommended way to register custom routes within Sitecore.
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}