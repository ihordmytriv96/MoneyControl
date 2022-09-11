using Microsoft.AspNetCore.Http;
using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;
using System.Security.Claims;

namespace MoneyControl.WebAPI.Application.Services
{
    public class MoneyLimiterManager : IMoneyLimiterManager
    {
        private readonly IMoneyLimiterRepository _moneyLimiterRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IExpensesTypeRepository _expensesTypeRepository;

        public MoneyLimiterManager(IMoneyLimiterRepository moneyLimiterRepository,
            IHttpContextAccessor httpContextAccessor,
            IExpensesTypeRepository expensesTypeRepository)
        {
            _moneyLimiterRepository = moneyLimiterRepository;
            _httpContextAccessor = httpContextAccessor;
            _expensesTypeRepository = expensesTypeRepository;
        }

        public async Task<MoneyLimiter> CreateLimitAsync(MoneyLimiter moneyLimiter, CancellationToken token)
        {
            moneyLimiter.MoneySpent = 0;
            moneyLimiter.UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await _moneyLimiterRepository.CreateAsync(moneyLimiter, token);
            return moneyLimiter;
        }

        public async Task RemoveLimitAsync(string Id, CancellationToken token)
        {
            await _moneyLimiterRepository.RemoveAsync(Id, token);
        }

        public async Task<MoneyLimiter> UpdateLimiterAsync(MoneyLimiter newMoneyLimiter, CancellationToken token)
        {
            var limiter = await _moneyLimiterRepository.FindOneAsync(x => x.Id == newMoneyLimiter.Id, token);
            if (!string.IsNullOrEmpty(newMoneyLimiter.ExpensesTypeId))
            {
                var expensesType = await _expensesTypeRepository.FindOneAsync(x => x.Id == newMoneyLimiter.ExpensesTypeId, token);
                limiter.ExpensesTypeId = newMoneyLimiter.ExpensesTypeId;
            }

            if (newMoneyLimiter.LimitStart != null)
            {
                limiter.LimitStart = newMoneyLimiter.LimitStart;
            }

            if (newMoneyLimiter.LimitEnd != null)
            {
                limiter.LimitEnd = newMoneyLimiter.LimitEnd;
            }

            if (newMoneyLimiter.MoneyLimit != null)
            {
                limiter.MoneyLimit = newMoneyLimiter.MoneyLimit;
            }

            await _moneyLimiterRepository.UpdateAsync(limiter, token);

            return limiter;
        }
    }
}
