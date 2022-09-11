using MoneyControl.WebAPI.Application.Services.Models;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Contracts
{
    public interface IPaymentsManager
    {
        public Task<Payment> CreatePaymentAsync(Payment Expenses, CancellationToken token);
        public Task<Payment> RemovePaymentAsync(string Id, CancellationToken token);
        public Task<List<Payment>> GetAllPaymentsAsync(CancellationToken token);
        public FullPaymentModel CreateFullPaymentModel(User user, ExpensesType expensesType, Payment record);
    }
}
