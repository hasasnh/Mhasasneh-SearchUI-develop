using System.Collections.Generic;

namespace Mhasasneh.Foundation.Core.Reflections.Interfaces
{
    public interface IChildren
    {
        string Key { get;}
        IReflectionBase Fill(List<string> childrens, IReflectionBase obj);

        IReflectionBase Fill(Dictionary<string, string> childrens, IReflectionBase obj);
        
    }
}
