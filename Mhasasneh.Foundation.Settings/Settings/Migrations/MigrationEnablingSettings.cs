using Mhasasneh.Foundation.Core.Settings.Migrations.Constants;
using Mhasasneh.Foundation.Core.Settings.Migrations.Interfaces;
using Sitecore.Configuration;
using Sitecore.Diagnostics;

namespace Mhasasneh.Foundation.Core.Settings.Migrations
{
    public class MigrationEnablingSettings : IMigrationEnablingSettings
    {
        private static readonly object LockObject = new object();
        private static volatile IMigrationEnablingSettings _current;

        #region public properties
        public bool EnableNewsMigration { get; private set; }
        public bool EnableCountryMigration { get; private set; }
        public bool EnableAnnouncementMigration { get; private set; }
        public bool EnableFaqMigration { get; private set; }
        public bool EnableLoungeMigration { get; private set; }
        public bool EnableAirportsMigration { get; private set; }
        public bool EnableOfferMigration { get; private set; }
        /// <summary>
        /// EnableForeignMissionsMigration
        /// </summary>
        public bool EnableForeignMissionsMigration { get; private set; }
        public bool EnableAdvancedArticlesMigration { get; private set; }
        public bool EnablePageTeaserMigration { get; private set; }
        public bool EnablePromotionsMigration { get; private set; }
        public bool EnableOfficesMigration { get; private set; }
        public bool EnableEmbassyMigration { get; private set; }
        #endregion

        /// <summary>
        /// Get the current singleton object.
        /// </summary>
        public static IMigrationEnablingSettings Current
        {
            get
            {
                if (_current == null)
                {
                    lock (LockObject)
                    {
                        if (_current == null)
                        {
                            _current = CreateNewSettings();
                        }
                    }
                }

                return _current;
            }
        }

        IMigrationEnablingSettings IMigrationEnablingSettings.Current => Current;

      



        /// <summary>
        /// Get migrationEnabling settings as strong type object
        /// </summary>
        /// <returns></returns>
        private static IMigrationEnablingSettings CreateNewSettings()
        {
            var settings = Factory.CreateObject(MigrationEnablingSettingsConstants.ConfigurationNodes, true) as IMigrationEnablingSettings;

            Assert.IsNotNull(settings, "migrationEnabling settings must be set in configuration!");
            return settings;
        }
    }
}
