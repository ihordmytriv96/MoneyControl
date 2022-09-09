using MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies;
using MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies.Filters;

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
            ExpensesManagerRegisterDependencies.RegisterDependencies(services);
            ExpensesTypeFilterRegisterDependencies.RegisterDependencies(services);
            PredicateBuilderRegisterDependencies.RegisterDependencies(services);
            ExpensesFilterRegisterDependencies.RegisterDependencies(services);

            // Mapper

            MapperRegisterDependencies.RegisterDependencies(services);

            // HttpContext

            HttpContextAccessorRegisterDependencies.RegisterDependencies(services);
        }
    }
}
