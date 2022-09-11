using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Services
{
    public class ExpensesTypeManager : IExpensesTypeManager
    {
        private readonly IExpensesTypeRepository _expensesTypeRepository;

        public ExpensesTypeManager(IExpensesTypeRepository expensesTypeRepository)
        {
            _expensesTypeRepository = expensesTypeRepository;
        }

        public async Task<ExpensesType> CreateNewExpensesTypeAsync(ExpensesType expensesType, CancellationToken token)
        {
            var result = await _expensesTypeRepository.CreateAsync(expensesType, token);
            return result;
        }

        public async Task<ExpensesType> GetExpensesTypeAsync(string Id, CancellationToken token)
        {
            return await _expensesTypeRepository.GetAsync(Id, token);
        }

        public async Task RemoveExpensesTypeAsync(string Id, CancellationToken token)
        {
            await _expensesTypeRepository.RemoveAsync(Id, token);
        }
    }
}
