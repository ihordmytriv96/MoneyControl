using MoneyControl.WebAPI.Data.Config.Mongo;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.WebAPI.Data.Repositories
{
    public class MongoMoneyLimiterRepository : MongoBaseRepository<MoneyLimiter>, IMoneyLimiterRepository
    {
        public MongoMoneyLimiterRepository(IMongoDbSettings settings) : base(settings)
        {
        }

        public override string CollectionName { get; set; } = "MoneyLimiters";
    }
}
