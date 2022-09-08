using Microsoft.AspNetCore.Http;
using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;
using System.Security.Claims;

namespace MoneyControl.WebAPI.Application.Services
{
    public class ExpensesManager : IExpensesManager
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExpensesManager(IExpensesRepository expensesRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _expensesRepository = expensesRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Expenses> CreateExpenses(Expenses expenses, CancellationToken token)
        {
            expenses.WhenSpent = DateTime.UtcNow;
            expenses.UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; 
            
            return await _expensesRepository.CreateAsync(expenses, token);
        }

        public async Task<List<Expenses>> GetAllExpenses(CancellationToken token)
        {
            return await _expensesRepository.GetAllAsync(token);
        }

        public async Task<Expenses> RemoveExpenses(string Id, CancellationToken token)
        {
            return await _expensesRepository.RemoveAsync(Id, token);
            
        }
    }
}
