using System;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Mhasasneh.Foundation.Operators.Base;
using Mhasasneh.Foundation.Operators.Interfaces;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Utils.Utils.DateAndTime;

namespace Mhasasneh.Foundation.Operators.Comparisons
{
    public class GreaterThan : BaseOperator, IOperator
    {
        public string Identifier => ">";

        public Expression<Func<SearchHit<SearchResultItem>, bool>> BuildCondition(SearchSettings settings, Expression<Func<SearchHit<SearchResultItem>, bool>> predicateBuilder)
        {
            var compareFileds = GetCompareFileds(settings, Identifier);

            if (settings.CompareFiledType == "Date")
            {
                var fDate = DateTime.Parse(compareFileds.FirstOrDefault().filedToCompareWith);
                predicateBuilder = predicateBuilder.Or(i => DateTimeConverter.ToStringDate(i.Document.GetItem().Fields[compareFileds.FirstOrDefault().filedToGetFromItem].Value) > fDate);
            }
            else if (settings.CompareFiledType == "Number")
            {
                var fNumber = Int32.Parse(compareFileds.FirstOrDefault().filedToCompareWith);
                predicateBuilder = predicateBuilder.Or(i => Int32.Parse(i.Document.GetItem().Fields[compareFileds.FirstOrDefault().filedToGetFromItem].Value) > fNumber);
            }
            return predicateBuilder;
        }
    }
}
