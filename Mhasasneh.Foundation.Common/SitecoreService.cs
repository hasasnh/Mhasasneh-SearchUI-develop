using Sitecore.Data;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Common.Options;
using static Mhasasneh.Foundation.Common.Options.GetItemOptions;

namespace Mhasasneh.Foundation.Common
{
    public class SitecoreService : ISitecoreService
    {
        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>The database.</value>
        public Database Database { get; private set; }

        public string DatabaseName { get; set; }

        public string Index { get; set; }

        private Database _database;
        protected Database DB
        {
            get
            {
                if (_database == null)
                {
                    _database = Sitecore.Context.Database;
                }

                return _database;
            }
        }

        public SitecoreService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreService"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="contextName">Name of the context.</param>
        public SitecoreService(Database database)
        {
            Database = database;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreService"/> class.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="contextName">Name of the context.</param>
        public SitecoreService(string databaseName, string index, string contextName = "Default")
        {
            DatabaseName = databaseName;
            Index = index;
        }

        public Sitecore.Data.Items.Item GetItemById<T>(GetItemByIdOptions options)
        {
            return DB?.GetItem(ID.Parse(options.Id));
        }

        public Sitecore.Data.Items.Item GetItemById(GetItemByIdOptions options)
        {
            return DB?.GetItem(ID.Parse(options.Id));
        }

        public T GetItem<T>(GetItemOptions options) where T : class
        {
            throw new System.NotImplementedException();
        }

        public T CreateItem<T>(CreateOptions options) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void SaveItem(SaveOptions options)
        {
            throw new System.NotImplementedException();
        }
    }
}
