using Mhasasneh.Foundation.Common.Options;
using static Mhasasneh.Foundation.Common.Options.GetItemOptions;

namespace Mhasasneh.Foundation.Common.Interfaces
{
    public interface ISitecoreService
    {
        string DatabaseName { get; set; }

        string Index { get; set; }

        /// <summary>
        /// Get sitecore item by id
        /// </summary>
        /// <typeparam name="T">item</typeparam>
        /// <param name="options">option param</param>
        /// <returns>Sitecore item/returns>
        Sitecore.Data.Items.Item GetItemById<T>(GetItemByIdOptions options);

        // <summary>
        /// Get sitecore item by id
        /// </summary>
        /// <param name="options">option param</param>
        /// <returns>Sitecore item/returns>
        Sitecore.Data.Items.Item GetItemById(GetItemByIdOptions options);

        /// <summary>
        /// Map an item to the requested type.
        /// </summary>
        /// <param name="options">Options for how the model will be retrieved</param>
        T GetItem<T>(GetItemOptions options) where T : class;

        /// <summary>
        /// Create an item to the Sitecore database.
        /// </summary>
        /// <param name="options">Options for how the model will be Created</param>
        T CreateItem<T>(CreateOptions options)
            where T : class;

        /// <summary>
        /// Save an item to the Sitecore database.
        /// </summary>
        /// <param name="options">Options for how the model will be saved</param>
        void SaveItem(SaveOptions options);
    }
}
