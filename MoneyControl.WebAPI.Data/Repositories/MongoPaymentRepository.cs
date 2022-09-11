using MoneyControl.WebAPI.Data.Config.Mongo;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Data.Repositories
{
    public class MongoPaymentRepository : MongoBaseRepository<Payment>, IPaymentRepository
    {
        public MongoPaymentRepository(IMongoDbSettings settings) : base(settings)
        {
        }
        public override string CollectionName { get; set; } = "Payments";
    }
}
