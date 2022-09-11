﻿using MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies;

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
            RecordManagerRegisterDependencies.RegisterDependencies(services);

            // Mapper

            MapperRegisterDependencies.RegisterDependencies(services);

            // HttpContext

            HttpContextAccessorRegisterDependencies.RegisterDependencies(services);
        }
    }
}
