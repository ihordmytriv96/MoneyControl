using MoneyControl.WebAPI.Application.Contracts.Authorization.Utilities;
using MoneyControl.WebAPI.Application.Services.Authorization.Utilities;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class TokenRefresherRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<ITokenRefresher, TokenRefresher>();
        }
    }
}
