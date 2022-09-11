using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Mappers;
using MoneyControl.WebAPI.Host.Mappers.ExpensesMappers;
using MoneyControl.WebAPI.Host.Mappers.ExpensesTypeMappers;
using MoneyControl.WebAPI.Host.Models.ExpensesModels;
using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class MapperRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IBaseMapper<ExpensesTypeModel, ExpensesType>, ExpensesTypeMapper>();
            services.AddTransient<IBaseMapper<CreatePaymentModel, Payment>, CreatePaymentMapper>();
        }
    }
}
