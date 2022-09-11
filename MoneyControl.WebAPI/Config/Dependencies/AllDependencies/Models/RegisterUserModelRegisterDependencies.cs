using MoneyControl.WebAPI.Application.Contracts.Models.AuthModels;
using MoneyControl.WebAPI.Host.Models.UserModels;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies.Models
{
    public static class RegisterUserModelRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IRegisterUserModel, RegisterUserModel>();
        }
    }
}
