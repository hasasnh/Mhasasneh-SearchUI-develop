using System.Collections.Generic;

namespace Mhasasneh.Foundation.Core.Reflections.Interfaces
{
    public interface IReflectionBase
    {
        List<string> Value { get; set; }
        List<string> Scopes { get; set; }
        List<string> Facets { get; set; }
        Dictionary<string, string> Queries { get; set; }
        string WordToSearch { get; set; }
        List<string> Enabled { get; set; }
    }
}
