using System.Linq.Expressions;

namespace MoneyControl.WebAPI.Domain.Contracts.Filter
{
    public interface IEntityFilter<TEntity, TEntityModel>
    {
        public Expression<Func<TEntity, bool>> Filter(TEntityModel model);
    }
}
