﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.WebAPI.Application.Contracts.Authorization;
using MoneyControl.WebAPI.Application.Services.Models.AuthModels;

namespace MoneyControl.WebAPI.Host.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationManager _authManager;

        public AuthorizationController(IAuthorizationManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserModel model,CancellationToken token)
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
            await _authManager.RegisterUserAsync(model, token);
            return Ok("Register complite");
        }
    }
}
