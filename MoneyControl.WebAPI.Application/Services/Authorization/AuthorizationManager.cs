using Microsoft.AspNetCore.Http;
using MoneyControl.WebAPI.Application.Contracts.Authorization;
using MoneyControl.WebAPI.Application.Contracts.Authorization.Utilities;
using MoneyControl.WebAPI.Application.Contracts.Models.AuthModels;
using MoneyControl.WebAPI.Application.Exceptions;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;
using System.Security.Claims;

namespace MoneyControl.WebAPI.Application.Services.Authorization
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private readonly IHashProcessor _hashProcessor;
        private readonly IUserRepository _userRepository;
        private readonly ITokenCreator _tokenCreator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationManager(IHashProcessor hashProcessor,
            IUserRepository userRepository,
            ITokenCreator tokenCreator,
            IHttpContextAccessor httpContextAccessor)
        {
            _hashProcessor = hashProcessor;
            _userRepository = userRepository;
            _tokenCreator = tokenCreator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> LoginAsync(ILoginUserModel userModel, CancellationToken token)
        {
            var user = (await _userRepository.FindAsync(x => x.Login == userModel.Login, token)).FirstOrDefault();
            if (user == null)
            {
                throw new UserNotFoundException("User not found");
            }

            if (!_hashProcessor.VerifyPasswordHash(userModel.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new WrongPasswordException("Wrong password");
            }

            var accessToken = _tokenCreator.CreateAccessToken(user);

            var refreshToken = _tokenCreator.CreateRefreshToken();
            SetRefreshToken(user, refreshToken);
            await _userRepository.UpdateAsync(user, token);

            return accessToken;
        }

        public async Task LogoutAsync(CancellationToken token)
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var user = await _userRepository.FindOneAsync(x => x.Login == userName, token);

            user.RefreshToken = String.Empty;
            user.TokenCreated = null;
            user.TokenExpires = null;

            await _userRepository.UpdateAsync(user, token);
        }

        public async Task RegisterUserAsync(IRegisterUserModel userModel, CancellationToken token)
        {
            User user = new User();
            _hashProcessor.CreatePasswordHash(userModel.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            user.Login = userModel.Login;
            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;

            await _userRepository.CreateAsync(user, token);
        }

        public void SetRefreshToken(User user, RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            user.RefreshToken = refreshToken.Token;
            user.TokenExpires = refreshToken.Expires;
            user.TokenCreated = refreshToken.Created;
        }
    }
}
