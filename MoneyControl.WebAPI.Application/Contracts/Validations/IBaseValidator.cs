namespace MoneyControl.WebAPI.Application.Contracts.Validations
{
    public interface IBaseValidator<TEntity>
    {
        public Task IsValidAsync(TEntity entity, CancellationToken token);
    }
}
