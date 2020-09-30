namespace Mhasasneh.Foundation.Core.Settings.Migrations.Interfaces
{
    public interface IMigrationEnablingSettings
    {
        /// <summary>
        /// Enable or disable news migration feature
        /// </summary>
        bool EnableNewsMigration { get; }

        /// <summary>
        /// Enable or disable country migration feature
        /// </summary>
        bool EnableCountryMigration { get; }

        /// <summary>
        /// Enable or disable announcement migration feature
        /// </summary>
        bool EnableAnnouncementMigration { get; }

        /// <summary>
        /// Enable or disable FAQ migration feature
        /// </summary>
        bool EnableFaqMigration { get; }

        /// <summary>
        /// Enable or disable Lounge migration feature
        /// </summary>
        bool EnableLoungeMigration { get; }

        /// <summary>
        /// Enable or disable Airports migration feature
        /// </summary>
        bool EnableAirportsMigration { get; }

        /// <summary>
        ///  Enable or disable ForeignMissions migration feature
        /// </summary>
        bool EnableForeignMissionsMigration { get; }

        /// <summary>
        /// Enable or disable announcement migration feature
        /// </summary>
        bool EnableAdvancedArticlesMigration { get; }

        /// <summary>
        /// EnableOfficesMigration
        /// </summary>
        bool EnableOfficesMigration { get; }

        /// <summary>
        /// Enable or disable announcement migration feature
        /// </summary>
        bool EnablePageTeaserMigration { get; }

        /// <summary>
        /// Enable or disable offer migration feature
        /// </summary>
        bool EnableOfferMigration { get; }

        /// <summary>
        /// Enable or disable Ptomotions migration feature
        /// </summary>
        bool EnablePromotionsMigration { get; }


        /// <summary>
        /// Enable or disable Ptomotions migration feature
        /// </summary>
        bool EnableEmbassyMigration { get; }

        /// <summary>
        /// Get current singleton object.
        /// </summary>
        IMigrationEnablingSettings Current { get; }
    }
}
