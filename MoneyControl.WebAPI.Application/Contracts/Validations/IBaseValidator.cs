namespace MoneyControl.WebAPI.Application.Contracts.Validations
{
    public interface IBaseValidator<TEntity>
    {
        public Task<List<string>> IsValidAsync(TEntity entity, CancellationToken token);
    }
}
