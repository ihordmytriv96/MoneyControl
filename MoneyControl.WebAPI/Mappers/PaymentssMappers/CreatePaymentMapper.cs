using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.ExpensesModels;

namespace MoneyControl.WebAPI.Host.Mappers.ExpensesMappers
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
