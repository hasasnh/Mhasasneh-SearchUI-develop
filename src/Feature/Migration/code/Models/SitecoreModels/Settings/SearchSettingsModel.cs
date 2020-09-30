using System.Collections.Generic;
using Mhasasneh.Foundation.Core.Attributes;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;

namespace TripleM.Feature.SearchUI.Models.SitecoreModels.Settings
{
    public class SearchSettingsModel : IReflectionBase
    {
        [SeparatedToList("Mhasasneh.Foundation.Core.Reflections.AttributeCommaSeparated", "{4A059303-C9F0-422B-87C1-A48CD4E40D29}")]
        public virtual List<string> Value { get; set; }

        [SeparatedToList("Mhasasneh.Foundation.Core.Reflections.AttributeCommaSeparated", "{FC287DD7-C674-4186-8BEF-6E47DA0B9B2D}")]
        public virtual List<string> Enabled { get; set; }

        [MultiList("Mhasasneh.Foundation.Core.Reflections.AttributeMultiList", "{7A460883-CD62-42EF-8A69-507577189961}")]
        public List<string> Scopes { get; set; }

        [Children("Mhasasneh.Foundation.Core.Reflections.AttributeChildren", "{D426F450-E994-4F2E-8995-8FC49F71C857}", "{F84BA453-FA2E-4041-9AA9-8AC28D22F88C}", "Name")]
        public List<string> Facets { get; set; }

        [Children("Mhasasneh.Foundation.Core.Reflections.AttributeChildren", "{66FD1BA5-EEEB-4DB6-BE2A-54FB30D63C6D}", fileds: "Value")]
        public Dictionary<string, string> Queries { get; set; }
        public string WordToSearch { get; set; }
    }
}