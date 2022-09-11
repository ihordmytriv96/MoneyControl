using MoneyControl.WebAPI.Data.Filter;
using MoneyControl.WebAPI.Data.Filter.Contracts;
using MoneyControl.WebAPI.Domain.Contracts.Filter;
using MoneyControl.WebAPI.Domain.Entities;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies.Filters
{
    public static class ExpensesFilterRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IEntityFilter<Record, IExpensesFilterModel>, RecordFilter>();
        }
    }
}
