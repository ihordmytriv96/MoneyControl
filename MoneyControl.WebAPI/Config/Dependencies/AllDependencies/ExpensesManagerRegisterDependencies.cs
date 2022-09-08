using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Application.Services;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class ExpensesManagerRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IExpensesManager, ExpensesManager>();
        }
    }
}
