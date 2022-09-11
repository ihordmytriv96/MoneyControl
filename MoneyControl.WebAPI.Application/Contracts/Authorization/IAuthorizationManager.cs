using MoneyControl.WebAPI.Application.Contracts.Models.AuthModels;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Contracts.Authorization
{
    public interface IAuthorizationManager
    {
        public Task<string> LoginAsync(ILoginUserModel userModel, CancellationToken token);
        public Task RegisterUserAsync(IRegisterUserModel userModel, CancellationToken token);
        public Task LogoutAsync(CancellationToken token);
        public void SetRefreshToken(User user, RefreshToken refreshToken);
    }
}
