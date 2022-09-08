using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Contracts
{
    public interface IExpensesTypeManager
    {
        public Task<ExpensesType> GetExpensesType(string Id, CancellationToken token);
        public Task<ExpensesType> CreateNewExpensesType(ExpensesType ExpensesType, CancellationToken token);
        public Task RemoveExpensesType(string Id, CancellationToken token);
    }
}
