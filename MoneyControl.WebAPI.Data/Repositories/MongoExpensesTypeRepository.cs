using MoneyControl.WebAPI.Data.Config.Mongo;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Data.Repositories
{
    public class MongoExpensesTypeRepository : MongoBaseRepository<ExpensesType>, IExpensesTypeRepository
    {
        public MongoExpensesTypeRepository(IMongoDbSettings settings) : base(settings)
        {
        }
        public override string CollectionName { get; set; } = "ExpensesTypes";
    }
}
