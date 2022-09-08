using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;

namespace MoneyControl.WebAPI.Host.Mappers.ExpensesTypeMappers
{
    public class ExpensesTypeMapper : IBaseMapper<ExpensesTypeModel, ExpensesType>
    {
        public ExpensesType Map(ExpensesTypeModel map)
        => new ExpensesType()
        {
            TypeName = map.TypeName
        };
    }
}
