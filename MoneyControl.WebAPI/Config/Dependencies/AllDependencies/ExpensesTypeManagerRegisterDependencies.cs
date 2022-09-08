using MoneyControl.WebAPI.Application.Contracts;
using MoneyControl.WebAPI.Application.Services;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class ExpensesTypeManagerRegisterDependencies
    {
        public static void RegisterDepenedencies(IServiceCollection services)
        {
            services.AddTransient<IExpensesTypeManager, ExpensesTypeManager>();
        }
    }
}
