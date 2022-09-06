using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.WebAPI.Application.Contracts.Authorization;
using MoneyControl.WebAPI.Application.Contracts.Authorization.Utilities;
using MoneyControl.WebAPI.Application.Contracts.Validations;
using MoneyControl.WebAPI.Application.Services.Models.AuthModels;

namespace MoneyControl.WebAPI.Host.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationManager _authManager;
        private readonly IBaseValidator<UserModel> _userValidator;
        private readonly ITokenRefresher _tokenRefresher;

        public AuthorizationController(IAuthorizationManager authManager,
            IBaseValidator<UserModel> userValidator,
            ITokenRefresher tokenRefresher)
        {
            _authManager = authManager;
            _userValidator = userValidator;
            _tokenRefresher = tokenRefresher;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserModel model, CancellationToken token)
        {
            var accessToken = await _authManager.LoginAsync(model, token);
            return Ok(accessToken);
        }

        [Authorize]
        [HttpDelete("logout")]
        public async Task<ActionResult> Logout(CancellationToken token)
        {
            await _authManager.LogoutAsync(token);
            return Ok("Successfully");
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] UserModel model, CancellationToken token)
        {
            var validList = await _userValidator.IsValidAsync(model, token);
            if (validList.Any())
            {
                return BadRequest(validList);
            }
            await _userValidator.IsValidAsync(model, token);
            await _authManager.RegisterUserAsync(model, token);
            return Ok("Register complite");
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken(CancellationToken token)
        {
            var result = await _tokenRefresher.RefreshTokensAsync(token);
            return Ok(result);
        }
    }
}
