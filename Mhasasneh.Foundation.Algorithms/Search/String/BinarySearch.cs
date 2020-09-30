using System.Collections.Generic;
using Mhasasneh.Foundation.Algorithms.Search.String.Interfaces;

namespace Mhasasneh.Foundation.Solr.Algorithms.Search.String
{
    public class BinarySearch : ISearchAlgorithm
    {
        private List<string> operators = new List<string>() { "=", "<", "<=", ">", ">=" };
        public bool Contains(string str, string searchFor)
        {
            return search(str, searchFor).Count > 0;
        }

        public List<int> search(string str, string searchFor)
        {
            int start;
            int at;
            int end;
            int count;
            List<int> positions = new List<int>();

            end = str.Length;
            start = (end / 2) - 1;
            at = 0;
            string currentOperator = string.Empty;
            while ((start <= end) && (at > -1))
            {
                count = end - start;
                at = str.IndexOf(searchFor, start, count);

                if (at > 0)
                {
                    currentOperator = str.Substring(at, 1);
                    foreach (var oper in operators)
                    {
                        if (oper == str.Substring(at - 1, 1))
                        {
                            currentOperator = currentOperator.Insert(0, oper);
                            break;
                        }
                        else if (oper == str.Substring(at + 1, 1))
                        {
                            currentOperator = currentOperator.Insert(1, oper);
                            break;
                        }
                    }

                    if (currentOperator != searchFor)
                    {
                        break;
                    }
                }

                if (at == -1) break;

                positions.Add(at);
                start = at + 1;
            }

            return positions;
        }
    }
}
