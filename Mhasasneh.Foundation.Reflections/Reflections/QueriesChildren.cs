using System;
using System.Collections.Generic;
using Mhasasneh.Foundation.Core.Reflections.Interfaces;

namespace Mhasasneh.Foundation.Core.Reflections
{
    public class QueriesChildren : IChildren
    {
        public string Key => "Queries";

        public IReflectionBase Fill(Dictionary<string, string> childrens, IReflectionBase obj)
        {
            obj.Queries = childrens;
            return obj;
        }

        public IReflectionBase Fill(List<string> childrens, IReflectionBase obj)
        {
            throw new NotImplementedException();
        }
    }
}
