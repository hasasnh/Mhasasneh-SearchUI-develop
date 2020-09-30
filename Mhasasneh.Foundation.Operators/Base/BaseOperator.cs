using Sitecore.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Mhasasneh.Foundation.Algorithms.Search.String.Interfaces;
using Mhasasneh.Foundation.Solr.Algorithms.Search.String;
using Mhasasneh.Foundation.Common;


namespace Mhasasneh.Foundation.Operators.Base
{
    public class BaseOperator
    {
        private readonly BinarySearch _searchAlgorithm;
        private List<string> operators = new List<string>() { "=", "<", "<=", ">", ">=" };

        public BaseOperator()
        {
            _searchAlgorithm = (BinarySearch)ServiceLocator.ServiceProvider.GetService(typeof(ISearchAlgorithm));
        }


        public List<CompareFileds> GetCompareFileds(SearchSettings settings, string identifier)
        {
            List<CompareFileds> compareFileds = new List<CompareFileds>();
            CompareFileds compareFiled = new CompareFileds();
            var dateQuery = settings.Queries.Where(x => x.Key == settings.TemplateID).FirstOrDefault().Value;
            var positions = _searchAlgorithm.search(dateQuery, identifier);
            var filedToCompareWith = dateQuery.Substring(positions.FirstOrDefault() + 1)
                                    .Replace("=", "")
                                    .Replace("<", "")
                                    .Replace(">", "")
                                    .Replace("<=", "")
                                    .Replace(">=", "");
            var filedToGetFromItem = dateQuery.Substring(0, positions.FirstOrDefault())
                                    .Replace("=", "")
                                    .Replace("<", "")
                                    .Replace(">", "")
                                    .Replace("<=", "")
                                    .Replace(">=", "");
            compareFiled.filedToCompareWith = filedToCompareWith;
            compareFiled.filedToGetFromItem = filedToGetFromItem;
            compareFileds.Add(compareFiled);
            return compareFileds;
        }

    }
}
