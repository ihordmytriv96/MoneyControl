using MoneyControl.WebAPI.Data.Config.Mongo;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities.Base;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MoneyControl.WebAPI.Data.Repositories
{
    public abstract class MongoBaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMongoCollection<TEntity> _collection;
        public abstract string CollectionName { get; set; }
        public MongoBaseRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DataBaseName);
            _collection = database.GetCollection<TEntity>(CollectionName);
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken token)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken token)
        {
            return (await _collection.FindAsync(filter)).ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken token)
        {
            return (await _collection.FindAsync(x => true)).ToList();
        }

        public async Task<TEntity> GetAsync(string Id, CancellationToken token)
        {
            return (await _collection.FindAsync(x => x.Id == Id)).FirstOrDefault();
        }

        public async Task<TEntity> RemoveAsync(string Id, CancellationToken token)
        {
            return (await _collection.FindOneAndDeleteAsync(Id));
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token)
        {
            var options = new FindOneAndReplaceOptions<TEntity>
            {
                ReturnDocument = ReturnDocument.After
            };
            var filter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id);
            return await _collection.FindOneAndReplaceAsync(filter, entity, options);
        }
        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filter, CancellationToken token)
        {
            return (await _collection.FindAsync(filter)).FirstOrDefault();
        }
    }
}
