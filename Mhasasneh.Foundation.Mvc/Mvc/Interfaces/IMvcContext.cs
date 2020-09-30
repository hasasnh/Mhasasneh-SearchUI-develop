using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;

namespace Mhasasneh.Foundation.Core.Mvc.Interfaces
{
    public interface IMvcContext
    {
        ISitecoreService SitecoreService { get; }

        /// <summary>
        /// Maps the RenderingContext.CurrentOrNull.Rendering.DataSource to a model
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <returns></returns>
        T GetDataSourceItem<T>() where T : IReflectionBase, new();

        Sitecore.Data.Items.Item GetDataSourceSitecoreItem<T>() where T : class;
    }
}
