using MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies;
using MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies.Filters;
using MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies.Models;

namespace MoneyControl.WebAPI.Host.Config.Dependencies
{
    public static class DependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {

            // Data

            MongoDbRegisterDependencies.RegisterDependencies(services);

            // Application
            TokenRefresherRegisterDependencies.RegisterDependencies(services);
            TokenCreatorRegisterDependencies.RegisterDependencies(services);
            HashProcessorRegisterDependencies.RegisterDependencies(services);
            AuthorizationManagerRegisterDependencies.RegisterDependencies(services);
            ValidatorsRegisterDependencies.RegisterDependencies(services);
            ExpensesTypeManagerRegisterDependencies.RegisterDepenedencies(services);
            PaymentsManagerRegisterDependencies.RegisterDependencies(services);
            LoginUserModelRegisterDependencies.RegisterDependencies(services);
            RegisterUserModelRegisterDependencies.RegisterDependencies(services);
            PredicateBuilderRegisterDependencies.RegisterDependencies(services);
            PaymentFilterRegisterDependencies.RegisterDependencies(services);
            ExpensesTypeFilterRegisterDependencies.RegisterDependencies(services);
            MoneyLimiterManagerRegisterDependencies.RegisterDependencies(services);

            // Mapper

            MapperRegisterDependencies.RegisterDependencies(services);

            // HttpContext

            HttpContextAccessorRegisterDependencies.RegisterDependencies(services);
        }
    }
}
