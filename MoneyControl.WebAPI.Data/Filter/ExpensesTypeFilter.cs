using MoneyControl.WebAPI.Data.Contracts.Utilities;
using MoneyControl.WebAPI.Data.Filter.Contracts;
using MoneyControl.WebAPI.Domain.Contracts.Filter;
using MoneyControl.WebAPI.Domain.Entities;
using System.Linq.Expressions;

namespace MoneyControl.WebAPI.Data.Filter
{
    public class ExpensesTypeFilter : IEntityFilter<ExpensesType, IExpensesTypeFilterModel>
    {
        private readonly IPredicateBuilder _predicateBuilder;

        public ExpensesTypeFilter(IPredicateBuilder predicateBuilder)
        {
            _predicateBuilder = predicateBuilder;
        }

        public Expression<Func<ExpensesType, bool>> Filter(IExpensesTypeFilterModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var result = _predicateBuilder.True<ExpensesType>();

            if (!string.IsNullOrEmpty(model.ExpensesTypeName))
            {
                result = _predicateBuilder.And(result, x => x.TypeName.Contains(model.ExpensesTypeName));
            }

            return result;
        }
    }
}