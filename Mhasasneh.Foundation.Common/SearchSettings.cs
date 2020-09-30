using System.Collections.Generic;

namespace Mhasasneh.Foundation.Common
{
    public class SearchSettings
    {
        public List<string> Value { get; set; }
        public List<string> Enabled { get; set; }
        public List<string> Scopes { get; set; }
        public List<string> Facets { get; set; }
        public Dictionary<string, string> Queries { get; set; }
        public string CompareFiledType { get; set; }

        public string TemplateID { get; set; }

        public string WordToSearch { get; set; }
    }
}