using MoneyControl.WebAPI.Application.Contracts.Validations;
using MoneyControl.WebAPI.Application.Services.Models.AuthModels;
using MoneyControl.WebAPI.Application.Services.Validations;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class ValidatorsRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IBaseValidator<UserModel>, UserValidationManager>();
            services.AddTransient<IBaseValidator<ExpensesType>, ExpensesTypeValidationManager>();
        }
    }
}
