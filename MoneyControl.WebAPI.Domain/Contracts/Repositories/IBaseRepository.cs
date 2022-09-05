using MoneyControl.WebAPI.Domain.Contracts.BaseEntity;
using System.Linq.Expressions;

namespace MoneyControl.WebAPI.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : IEntity
    {
        public Task<List<TEntity>> GetAllAsync(CancellationToken token);
        public Task<TEntity> GetAsync(string Id, CancellationToken token);
        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter, CancellationToken token);
        public Task<TEntity> CreateAsync(TEntity entity, CancellationToken token);
        public Task<TEntity> RemoveAsync(string Id, CancellationToken token);
        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token);
    }
}
