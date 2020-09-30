using System.Collections.Generic;

namespace Mhasasneh.Foundation.Core.Reflections.Interfaces
{
    public interface ICommaSeparated
    {
        string Key { get; }
        IReflectionBase Fill(List<string> value, IReflectionBase obj);
    }
}
