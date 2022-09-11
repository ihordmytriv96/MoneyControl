using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.MoneyLimiterModels;

namespace MoneyControl.WebAPI.Host.Mappers.MoneyLimiterMappers
{
    public class LimitMapper : IBaseMapper<MoneyLimiter, LimitModel>
    {
        public LimitModel Map(MoneyLimiter map)
        => new LimitModel()
        {
            ExpensesTypeId = map.ExpensesTypeId,
            LimitEnd = map.LimitEnd,
            LimitStart = map.LimitStart,
            MoneyLimit = map.MoneyLimit,
            MoneySpent = map.MoneySpent
        };
    }
}
