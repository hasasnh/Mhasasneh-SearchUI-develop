using System.Collections.Generic;
using System.Linq;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;

namespace Mhasasneh.Foundation.Core.Reflections
{
    public class FacetsChildren : IChildren
    {
        public string Key => "Facets";

        public IReflectionBase Fill(List<string> childrens, IReflectionBase obj)
        {
            obj.Facets = childrens;
            return obj;
        }

        public IReflectionBase Fill(Dictionary<string, string> childrens, IReflectionBase obj)
        {
            if (childrens == null) return null;
            return Fill(childrens.Values.ToList(), obj);
        }
    }
}
