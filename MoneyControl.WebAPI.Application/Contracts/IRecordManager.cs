using MoneyControl.WebAPI.Application.Services.Models;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Contracts
{
    public interface IRecordManager
    {
        public Task<Record> CreateRecordAsync(Record Expenses, CancellationToken token);
        public Task<Record> RemoveRecordAsync(string Id, CancellationToken token);
        public Task<List<Record>> GetAllRecordsAsync(CancellationToken token);
        public FullRecordModel CreateFullRecordModel(User user, ExpensesType expensesType, Record record);
    }
}
