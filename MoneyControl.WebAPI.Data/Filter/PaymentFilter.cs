using MoneyControl.WebAPI.Data.Contracts.Utilities;
using MoneyControl.WebAPI.Data.Filter.Contracts;
using MoneyControl.WebAPI.Domain.Contracts.Filter;
using MoneyControl.WebAPI.Domain.Entities;
using System.Linq.Expressions;

namespace MoneyControl.WebAPI.Data.Filter
{
    public class PaymentFilter : IEntityFilter<Payment, IPaymentFilterModel>
    {
        private readonly IPredicateBuilder _predicateBuilder;

        public PaymentFilter(IPredicateBuilder predicateBuilder)
        {
            _predicateBuilder = predicateBuilder;
        }

        public Expression<Func<Payment, bool>> Filter(IPaymentFilterModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var result = _predicateBuilder.True<Payment>();

            if (model.PaymentAddedDateStart.HasValue)
            {
                result = _predicateBuilder.And(result, x => x.WhenSpent >= model.PaymentAddedDateStart); 
            }

            if (model.PaymentAddedDateEnd.HasValue)
            {
                result = _predicateBuilder.And(result, x => x.WhenSpent <= model.PaymentAddedDateEnd);
            }

            if (model.MoneySpend.HasValue)
            {
                result = _predicateBuilder.And(result, x => x.MoneySpent >= model.MoneySpend);
            }

            if (model.ExpensesTypeId.Any())
            {
                result = _predicateBuilder.And(result, x => model.ExpensesTypeId.Contains(x.ExpensesTypeId));                                           
            }


            return result;
        }
    }
}
