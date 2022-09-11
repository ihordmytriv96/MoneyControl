using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.MoneyLimiterModels;

namespace MoneyControl.WebAPI.Host.Mappers.MoneyLimiterMappers
{
    public class CreateLimitMapper : IBaseMapper<CreateLimitModel, MoneyLimiter>
    {
        public MoneyLimiter Map(CreateLimitModel map)
        => new MoneyLimiter()
        {
            ExpensesTypeId = map.ExpensesTypeId,
            LimitEnd = map.LimitEnd,
            LimitStart = map.LimitStart,
            MoneyLimit = map.MoneyLimit
        };
    }
}
