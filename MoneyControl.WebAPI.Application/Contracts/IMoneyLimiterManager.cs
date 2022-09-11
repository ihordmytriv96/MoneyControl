using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Contracts
{
    public interface IMoneyLimiterManager
    {
        public Task<MoneyLimiter> CreateLimitAsync(MoneyLimiter moneyLimiter, CancellationToken token);
        public Task RemoveLimitAsync(string Id, CancellationToken token);
        public Task<MoneyLimiter> UpdateLimiterAsync(MoneyLimiter moneyLimiter, CancellationToken token);

    }
}
