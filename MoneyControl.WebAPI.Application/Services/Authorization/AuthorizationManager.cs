using Microsoft.AspNetCore.Http;
using MoneyControl.WebAPI.Application.Contracts.Authorization;
using MoneyControl.WebAPI.Application.Contracts.Authorization.Utilities;
using MoneyControl.WebAPI.Application.Exceptions;
using MoneyControl.WebAPI.Application.Services.Models.AuthModels;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;
using MoneyControl.WebAPI.Domain.Entities;

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

        public async Task<string> LoginAsync(UserModel userModel, CancellationToken token)
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


        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(UserModel userModel, CancellationToken token)
        {
            User user = new User();
            _hashProcessor.CreatePasswordHash(userModel.Password, out byte[] PasswordSalt, out byte[] PasswordHash);
            user.Login = userModel.Login;
            user.PasswordHash = PasswordHash;
            user.PasswordSalt = PasswordSalt;

            _userRepository.CreateAsync(user, token);

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
