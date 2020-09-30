using System;
using Mhasasneh.Foundation.Core.Diagnostics.interfaces;
using System.Web.Mvc;
using TripleM.Feature.SearchUI.Models;
using Mhasasneh.Foundation.Core.Mvc.Interfaces;

namespace TripleM.Feature.SearchUI.Base
{
    public class BaseController : Controller
    {
        internal readonly IMvcContext _mvcContext = DependencyResolver.Current.GetService<IMvcContext>();
        internal readonly ILogger _logger = DependencyResolver.Current.GetService<ILogger>();
       // internal readonly IItemManagement _iItemManagement = DependencyResolver.Current.GetService<IItemManagement>();

        /// <summary>
        /// This is a common method for logging and show common component error
        /// </summary>
        /// <param name="ex">exception</param>
        /// <param name="message">error message</param>
        /// <returns>Html with error message</returns>
        internal ViewResult GlobalError(Exception ex = null, string message = null)
        {
            _logger.LogError($"{nameof(GlobalError)} Global Error Raised: {ex}");
            return View(
                "~/Views/Errors/GlobalError.cshtml",
                new GlobalErrorModel { Message = message });
        }
    }
}