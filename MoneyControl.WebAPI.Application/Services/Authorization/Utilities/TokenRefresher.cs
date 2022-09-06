using Microsoft.AspNetCore.Http;
using MoneyControl.WebAPI.Application.Contracts.Authorization;
using MoneyControl.WebAPI.Application.Contracts.Authorization.Utilities;
using MoneyControl.WebAPI.Application.Exceptions;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;

namespace MoneyControl.WebAPI.Application.Services.Authorization.Utilities
{
    public class TokenRefresher : ITokenRefresher
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly ITokenCreator _tokenCreator;
        private readonly IAuthorizationManager _authorizationManager;

        public TokenRefresher(IHttpContextAccessor contextAccessor,
            IUserRepository userRepository,
            ITokenCreator tokenCreator,
            IAuthorizationManager authorizationManager)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
            _tokenCreator = tokenCreator;
            _authorizationManager = authorizationManager;
        }

        public async Task<string> RefreshTokensAsync(CancellationToken token)
        {
            var refreshToken = _contextAccessor.HttpContext.Request.Cookies["refreshToken"];
            var user = (await _userRepository.FindAsync(x => x.RefreshToken == refreshToken, token)).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidRefreshTokenException("Invalid refresh token");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                throw new RefreshTokenExpiredException("Refresh token expired");
            }

            string accessToken = _tokenCreator.CreateAccessToken(user);
            var newRefreshToken = _tokenCreator.CreateRefreshToken();
            _authorizationManager.SetRefreshToken(user, newRefreshToken);
            await _userRepository.UpdateAsync(user, token);

            return accessToken;
        }
    }
}
