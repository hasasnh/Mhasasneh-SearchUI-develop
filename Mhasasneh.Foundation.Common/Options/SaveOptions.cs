using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mhasasneh.Foundation.Common.Options
{
    public class SaveOptions
    {
        public object Model { get; set; }

        public Type Type { get { return Model.GetType(); } }

        public SaveOptions() { }

    }
}
