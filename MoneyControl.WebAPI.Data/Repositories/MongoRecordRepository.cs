using MoneyControl.WebAPI.Data.Config.Mongo;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Data.Repositories
{
    public class MongoRecordRepository : MongoBaseRepository<Record>, IRecordRepository
    {
        public MongoRecordRepository(IMongoDbSettings settings) : base(settings)
        {
        }
        public override string CollectionName { get; set; } = "Expenses";
    }
}
