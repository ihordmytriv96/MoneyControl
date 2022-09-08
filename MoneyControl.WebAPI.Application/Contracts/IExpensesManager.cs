using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Contracts
{
    public interface IExpensesManager
    {
        public Task<Expenses> CreateExpenses(Expenses Expenses, CancellationToken token);
        public Task<Expenses> RemoveExpenses(string Id, CancellationToken token);
        public Task<List<Expenses>> GetAllExpenses(CancellationToken token);
    }
}
