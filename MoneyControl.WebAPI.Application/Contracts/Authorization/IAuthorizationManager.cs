﻿using MoneyControl.WebAPI.Application.Services.Models.AuthModels;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Application.Contracts.Authorization
{
    public interface IAuthorizationManager
    {
        public Task<string> LoginAsync(UserModel userModel, CancellationToken token);
        public Task RegisterUserAsync(UserModel userModel, CancellationToken token);
        public Task LogoutAsync(CancellationToken token);
        public void SetRefreshToken(User user, RefreshToken refreshToken);
    }
}
