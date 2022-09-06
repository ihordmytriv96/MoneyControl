using MoneyControl.WebAPI.Application.Contracts.Authorization;
using MoneyControl.WebAPI.Application.Services.Authorization;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class AuthorizationManagerRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IAuthorizationManager, AuthorizationManager>();
        }
    }
}
