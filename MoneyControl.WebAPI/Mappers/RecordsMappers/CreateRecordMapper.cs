using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.ExpensesModels;

namespace MoneyControl.WebAPI.Host.Mappers.ExpensesMappers
{
    public class CreateRecordMapper : IBaseMapper<CreateRecordModel, Record>
    {
        public Record Map(CreateRecordModel model)
        => new Record()
        {
            MoneySpent = model.MoneySpent,
            ExpensesTypeId = model.ExpensesTypeId,
        };
    }
}
