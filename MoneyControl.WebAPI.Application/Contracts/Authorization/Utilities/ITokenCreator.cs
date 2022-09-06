using MoneyControl.WebAPI.Application.Services.Models.AuthModels;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Contracts.Authorization.Utilities
{
    public interface ITokenCreator
    {
        public string CreateAccessToken(User user);
        public RefreshToken CreateRefreshToken();
    }
}
