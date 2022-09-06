using MoneyControl.WebAPI.Application.Contracts.Authorization.Utilities;

namespace MoneyControl.WebAPI.Application.Services.Authorization.Utilities
{
    public class TokenRefresher : ITokenRefresher
    {
        public Task<string> RefreshTokensAsync()
        {
            throw new NotImplementedException();
        }
    }
}
