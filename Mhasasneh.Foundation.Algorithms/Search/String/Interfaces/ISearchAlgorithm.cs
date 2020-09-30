using System.Collections.Generic;

namespace Mhasasneh.Foundation.Algorithms.Search.String.Interfaces
{
    public interface ISearchAlgorithm
    {
        bool Contains(string str, string searchFor);
        List<int> search(string str, string searchFor);
    }
}
