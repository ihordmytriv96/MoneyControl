using MoneyControl.WebAPI.Data.Config.Mongo;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Data.Repositories
{
    public class MongoExpencesTypeRepository : MongoBaseRepository<ExpencesType>, IExpencesTypeRepository
    {
        public MongoExpencesTypeRepository(IMongoDbSettings settings) : base(settings)
        {
        }
        public override string CollectionName { get; set; } = "ExpencesTypes";
    }
}
