using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.ExpensesModels;

namespace MoneyControl.WebAPI.Host.Mappers.ExpensesMappers
{
    public class CreateExpensesMapper : IBaseMapper<CreateExpensesModel, Expenses>
    {
        public Expenses Map(CreateExpensesModel model)
        => new Expenses()
        {
            MoneySpent = model.MoneySpent,
            ExpensesTypeId = model.ExpensesTypeId,
        };
    }
}
