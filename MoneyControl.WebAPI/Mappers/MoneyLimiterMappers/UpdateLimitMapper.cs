using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.MoneyLimiterModels;

namespace MoneyControl.WebAPI.Host.Mappers.MoneyLimiterMappers
{
    public class UpdateLimitMapper : IBaseMapper<UpdateLimitModel, MoneyLimiter>
    {
        public MoneyLimiter Map(UpdateLimitModel map)
        => new MoneyLimiter()
        {
            ExpensesTypeId = map.NewExpensesTypeId,
            LimitStart = map.NewLimitStart,
            LimitEnd = map.NewLimitEnd,
            MoneyLimit = map.NewMoneyLimit,
            Id = map.LimitId
        };
    }
}
