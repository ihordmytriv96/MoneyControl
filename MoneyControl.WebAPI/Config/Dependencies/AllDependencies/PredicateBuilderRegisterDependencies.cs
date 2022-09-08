using MoneyControl.WebAPI.Data.Contracts.Utilities;
using MoneyControl.WebAPI.Data.Utilities;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class PredicateBuilderRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IPredicateBuilder, PredicateBuilder>();
        }
    }
}
