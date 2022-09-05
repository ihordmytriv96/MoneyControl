using MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies;

namespace MoneyControl.WebAPI.Host.Config.Dependencies
{
    public static class DependenciesRegistrator
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
        
            // Data

            MongoDbRegisterDependencies.RegisterDependencies(services);

            // Application


            // Mapper

        }
    }
}
