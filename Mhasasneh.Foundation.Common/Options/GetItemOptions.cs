using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using System;

namespace Mhasasneh.Foundation.Common.Options
{
    public class GetItemOptions
    {

        public class GetItemOptionsParams : GetItemOptions
        {
            public virtual Language Language { get; set; }
            public virtual Sitecore.Data.Version Version { get; set; }
        }

        public class GetItemByPathOptions : GetItemOptions
        {
            public string Path { get; set; }

            public GetItemByPathOptions()
            {
            }
            public GetItemByPathOptions(string path)
            {
                Path = path;
            }

            public Item GetItem(Database database)
            {
                return null;
            }

        }

        public class GetItemByIdOptions : GetItemOptionsParams
        {
            public Guid Id { get; set; }

            public GetItemByIdOptions()
            {

            }

            public GetItemByIdOptions(Guid id)
            {
                Id = id;
            }
        }
    }
}
