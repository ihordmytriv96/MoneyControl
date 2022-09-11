using Microsoft.AspNetCore.Http;
using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Application.Services.Models;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;
using System.Security.Claims;

namespace MoneyControl.WebAPI.Application.Services
{
    public class PaymentsManager : IPaymentsManager
    {
        private readonly IPaymentRepository _expensesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaymentsManager(IPaymentRepository expensesRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _expensesRepository = expensesRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public FullPaymentModel CreateFullPaymentModel(User user, ExpensesType expensesType, Payment record)
        => new FullPaymentModel()
        {
            ExpensesType = expensesType.TypeName,
            MoneySpend = record.MoneySpent,
            WhenSpend = record.WhenSpent,
            UserFirstName = user.FirstName,
            UserLastName = user.LastName
        };

        public async Task<Payment> CreatePaymentAsync(Payment expenses, CancellationToken token)
        {
            expenses.WhenSpent = DateTime.UtcNow;
            expenses.UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; 
            
            return await _expensesRepository.CreateAsync(expenses, token);
        }

        public async Task<List<Payment>> GetAllPaymentsAsync(CancellationToken token)
        {
            return await _expensesRepository.GetAllAsync(token);
        }

        public async Task<Payment> RemovePaymentAsync(string Id, CancellationToken token)
        {
            return await _expensesRepository.RemoveAsync(Id, token);
            
        }
    }
}
