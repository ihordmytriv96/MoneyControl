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
        private readonly IPaymentRepository _paymentRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMoneyLimiterRepository _moneyLimiterRepository;

        public PaymentsManager(IPaymentRepository paymentRepository,
            IHttpContextAccessor httpContextAccessor,
            IMoneyLimiterRepository moneyLimiterRepository)
        {
            _paymentRepository = paymentRepository;
            _httpContextAccessor = httpContextAccessor;
            _moneyLimiterRepository = moneyLimiterRepository;
        }

        public FullPaymentModel CreateFullPaymentModel(User user, ExpensesType expensesType, Payment payment)
        => new FullPaymentModel()
        {
            ExpensesType = expensesType.TypeName,
            MoneySpend = payment.MoneySpent,
            WhenSpend = payment.WhenSpent,
            UserFirstName = user.FirstName,
            UserLastName = user.LastName
        };
       
        public async Task<Payment> CreatePaymentAsync(Payment payment, CancellationToken token)
        {
            payment.WhenSpent = DateTime.UtcNow;
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            payment.UserId = userId;
            var userLimiter = (await _moneyLimiterRepository.FindAsync(x => x.UserId == userId, token)).Where(x=>x.ExpensesTypeId == payment.ExpensesTypeId).FirstOrDefault();
            if (userLimiter != null)
            {
                userLimiter.MoneySpent += payment.MoneySpent;
            }
            
            return await _paymentRepository.CreateAsync(payment, token);
        }

        public async Task<List<Payment>> GetAllPaymentsAsync(CancellationToken token)
        {
            return await _paymentRepository.GetAllAsync(token);
        }

        public async Task<Payment> RemovePaymentAsync(string Id, CancellationToken token)
        {
            return await _paymentRepository.RemoveAsync(Id, token);
            
        }
    }
}
