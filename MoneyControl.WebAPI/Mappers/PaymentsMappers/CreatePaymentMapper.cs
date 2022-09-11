using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.PaymentsModels;

namespace MoneyControl.WebAPI.Host.Mappers.PaymentsMappers
{
    public class CreatePaymentMapper : IBaseMapper<CreatePaymentModel, Payment>
    {
        public Payment Map(CreatePaymentModel model)
        => new Payment()
        {
            MoneySpent = model.MoneySpent,
            ExpensesTypeId = model.ExpensesTypeId,
        };
    }
}
