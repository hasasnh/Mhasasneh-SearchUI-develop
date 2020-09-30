namespace Mhasasneh.Foundation.Core.Settings.Migrations.Interfaces
{
    public interface IMigrationEnablingSettings
    {
        /// <summary>
        /// Enable or disable Solr migration feature
        /// </summary>
        bool EnableSolrMigration { get; }

        /// <summary>
        /// Get current singleton object.
        /// </summary>
        IMigrationEnablingSettings Current { get; }
    }
}
