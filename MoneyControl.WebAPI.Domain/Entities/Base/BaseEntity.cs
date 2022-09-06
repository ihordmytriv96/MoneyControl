using MoneyControl.WebAPI.Domain.Contracts.BaseEntity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoneyControl.WebAPI.Domain.Entities.Base
{
    public class BaseEntity : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
