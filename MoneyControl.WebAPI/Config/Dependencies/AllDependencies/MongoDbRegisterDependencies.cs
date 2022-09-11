using Microsoft.Extensions.Options;
using MoneyControl.WebAPI.Data.Config.Mongo;
using MoneyControl.WebAPI.Data.Repositories;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class MongoDbRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            // Config

            services.Configure<MongoDbSettings>(((IConfiguration)provider.GetService(typeof(IConfiguration))).GetSection("MoneyControlStoreDatabase"));
            services.AddTransient<IMongoDbSettings>(serviceProvider =>
                             serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            // Repositories

            services.AddTransient<IPaymentRepository, MongoPaymentRepository>();
            services.AddTransient<IExpensesTypeRepository, MongoExpensesTypeRepository>();
            services.AddTransient<IUserRepository, MongoUserRepository>();
        }
    }
}
