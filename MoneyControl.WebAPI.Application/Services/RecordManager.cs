using Microsoft.AspNetCore.Http;
using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Application.Services.Models;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;
using System.Security.Claims;

namespace MoneyControl.WebAPI.Application.Services
{
    public class RecordManager : IRecordManager
    {
        private readonly IRecordRepository _expensesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RecordManager(IRecordRepository expensesRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _expensesRepository = expensesRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public FullRecordModel CreateFullRecordModel(User user, ExpensesType expensesType, Record record)
        => new FullRecordModel()
        {
            ExpensesType = expensesType.TypeName,
            MoneySpend = record.MoneySpent,
            WhenSpend = record.WhenSpent,
            UserFirstName = user.FirstName,
            UserLastName = user.LastName
        };

        public async Task<Record> CreateRecordAsync(Record expenses, CancellationToken token)
        {
            expenses.WhenSpent = DateTime.UtcNow;
            expenses.UserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; 
            
            return await _expensesRepository.CreateAsync(expenses, token);
        }

        public async Task<List<Record>> GetAllRecordsAsync(CancellationToken token)
        {
            return await _expensesRepository.GetAllAsync(token);
        }

        public async Task<Record> RemoveRecordAsync(string Id, CancellationToken token)
        {
            return await _expensesRepository.RemoveAsync(Id, token);
            
        }
    }
}
