using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.ExpensesModels;
using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;

namespace MoneyControl.WebAPI.Host.Mappers.ExpencesMappers
{
    public class ExpensesModelMapper : IBaseMapper<Expenses, ExpensesModel>
    {
        private readonly IBaseMapper<ExpensesType, ExpensesTypeModel> _mapper;

        public ExpensesModelMapper(IBaseMapper<ExpensesType, ExpensesTypeModel> mapper)
        {
            _mapper = mapper;
        }

        public ExpensesModel Map(Expenses map)
        => new ExpensesModel()
        {
            MoneySpent = map.MoneySpent,
            WhenSpent = map.WhenSpent
        };
    }
}
