using Mhasasneh.Foundation.Core.Reflections.Interfaces;
using System.Collections.Generic;

namespace Mhasasneh.Foundation.Core.Reflections
{
    class ValueCommaSeparated : ICommaSeparated
    {
        public ValueCommaSeparated()
        {

        }
        public string Key => "Value";

        public IReflectionBase Fill(List<string> value, IReflectionBase obj)
        {
            obj.Value = value;
            return obj;
        }
    }
}
