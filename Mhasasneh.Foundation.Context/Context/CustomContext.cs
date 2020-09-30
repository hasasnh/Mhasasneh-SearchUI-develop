using Sitecore.Mvc.Presentation;
using Mhasasneh.Foundation.Core.Context.Interfaces;
using Mhasasneh.Foundation.Cache.Interfaces;
using System;

namespace Mhasasneh.Foundation.Core.Context
{
   public class CustomContext : ICustomContext
    {

        private readonly INativeCache _nativeCache;
        private string _datasourceId;

        public CustomContext(INativeCache nativeCache)
        {
            _nativeCache = nativeCache;
        }

        public string CurrentDatasourceId
        {
            get
            {
                if (string.IsNullOrEmpty(_datasourceId))
                {
                    try
                    {
                        _datasourceId = !string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource)
                            ? RenderingContext.Current.Rendering.DataSource
                            : null;
                        _nativeCache.GetOrCreate<string>("CurrentDatasourceId", _datasourceId);
                    }
                    catch(Exception ex)
                    {
                        _datasourceId = _nativeCache.GetOrCreate<string>("CurrentDatasourceId", null);
                    }
                }

                return _datasourceId;
            }
        }

    }
}
