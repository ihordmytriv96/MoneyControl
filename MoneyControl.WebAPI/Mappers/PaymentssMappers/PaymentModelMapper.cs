using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.ExpensesModels;
using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;

namespace MoneyControl.WebAPI.Host.Mappers.ExpencesMappers
{
    public class PaymentModelMapper : IBaseMapper<Payment, PaymentModel>
    {
        public PaymentModel Map(Payment map)
        => new PaymentModel()
        {
            MoneySpent = map.MoneySpent,
            WhenSpent = map.WhenSpent
        };
    }
}
