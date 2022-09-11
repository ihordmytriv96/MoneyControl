using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;

namespace MoneyControl.WebAPI.Host.Mappers.ExpencesTypeMappers
{
    public class ExpensesTypeModelMapper : IBaseMapper<ExpensesType, ExpensesTypeModel>
    {
        public ExpensesTypeModel Map(ExpensesType map)
        => new ExpensesTypeModel()
        {
            ExpensesTypeId = map.Id,
            TypeName = map.TypeName
        };
    }
}
