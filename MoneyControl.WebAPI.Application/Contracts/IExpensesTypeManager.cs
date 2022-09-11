using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Contracts
{
    public interface IExpensesTypeManager
    {
        public Task<ExpensesType> GetExpensesTypeAsync(string Id, CancellationToken token);
        public Task<ExpensesType> CreateNewExpensesTypeAsync(ExpensesType ExpensesType, CancellationToken token);
        public Task RemoveExpensesTypeAsync(string Id, CancellationToken token);
    }
}
