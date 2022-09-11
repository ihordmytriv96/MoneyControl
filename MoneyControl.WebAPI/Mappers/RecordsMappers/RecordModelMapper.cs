using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.ExpensesModels;
using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;

namespace MoneyControl.WebAPI.Host.Mappers.ExpencesMappers
{
    public class RecordModelMapper : IBaseMapper<Record, RecordModel>
    {
        public RecordModel Map(Record map)
        => new RecordModel()
        {
            MoneySpent = map.MoneySpent,
            WhenSpent = map.WhenSpent
        };
    }
}
