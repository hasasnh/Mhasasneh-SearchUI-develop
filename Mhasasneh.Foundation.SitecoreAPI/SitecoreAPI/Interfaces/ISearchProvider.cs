using System.Threading.Tasks;

namespace Mhasasneh.Foundation.SitecoreAPI.SitecoreAPI.Interfaces
{
    /// <summary>
    /// This interface is responsible to define the signature for all methods needed to
    /// insert the received repo in sitecore 
    /// </summary>
    public interface ISearchProvider
    {
        /// <summary>
        /// Type name of provider
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Turn the feature on or off
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        ///Use this method to call save method to insert in sitecore based on received repo object type
        /// </summary>
        Task ExecuteAsync();

    }
}
