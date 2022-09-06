namespace MoneyControl.WebAPI.Application.Contracts.Authorization.Utilities
{
    public interface ITokenRefresher
    {
        public Task<string> RefreshTokensAsync(CancellationToken cancellationToken );
    }
}
