using Mhasasneh.Foundation.Core.Reflections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mhasasneh.Foundation.Core.Reflections
{
    class EnabledCommaSeparated : ICommaSeparated
    {
        public EnabledCommaSeparated()
        {

        }
        public string Key => "Enabled";

        public IReflectionBase Fill(List<string> value, IReflectionBase obj)
        {
            obj.Enabled = value;
            return obj;
        }
    }
}
