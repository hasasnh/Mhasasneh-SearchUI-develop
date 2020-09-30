using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.DependencyInjection;
using Mhasasneh.Foundation.Algorithms.Search.String.Interfaces;
using Mhasasneh.Foundation.Common;
using Mhasasneh.Foundation.Common.Interfaces;
using Mhasasneh.Foundation.Operators.Interfaces;
using static Mhasasneh.Foundation.Common.Options.GetItemOptions;
using System.Linq.Expressions;

namespace Mhasasneh.Foundation.Operators
{
    public class ComparisonBuilder : IComparisonBuilder
    {
        private readonly IEnumerable<IOperator> _operators;
        private readonly ISearchAlgorithm _searchAlgorithm;
        private readonly SitecoreService _sitecoreService;

        public ComparisonBuilder(IEnumerable<IOperator> operators, ISearchAlgorithm searchAlgorithm)
        {
            _operators = operators;
            _searchAlgorithm = searchAlgorithm;
            _sitecoreService = (SitecoreService)ServiceLocator.ServiceProvider.GetService(typeof(ISitecoreService)); ;
        }

        public Expression<Func<SearchHit<SearchResultItem>, bool>> Comparison(SearchSettings settings)
        {
            var query = settings.Queries.Where(x => x.Key == settings.TemplateID).FirstOrDefault().Value;
            settings.CompareFiledType = _sitecoreService.GetItemById(new GetItemByIdOptions { Id = Guid.Parse(settings.TemplateID) }).Name;
            var rootPredicates = PredicateBuilder.False<SearchHit<SearchResultItem>>();

            foreach (var oper in _operators)
            {
                if (_searchAlgorithm.Contains(query, oper.Identifier))
                {
                    rootPredicates = oper.BuildCondition(settings, rootPredicates);
                }
            }
            return rootPredicates;
        }
    }
}
