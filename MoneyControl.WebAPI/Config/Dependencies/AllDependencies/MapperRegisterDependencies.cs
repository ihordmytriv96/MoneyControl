using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Mappers;
using MoneyControl.WebAPI.Host.Mappers.ExpensesTypeMappers;
using MoneyControl.WebAPI.Host.Mappers.MoneyLimiterMappers;
using MoneyControl.WebAPI.Host.Mappers.PaymentsMappers;
using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;
using MoneyControl.WebAPI.Host.Models.MoneyLimiterModels;
using MoneyControl.WebAPI.Host.Models.PaymentsModels;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class MapperRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IBaseMapper<ExpensesTypeModel, ExpensesType>, ExpensesTypeMapper>();
            services.AddTransient<IBaseMapper<CreatePaymentModel, Payment>, CreatePaymentMapper>();
            services.AddTransient<IBaseMapper<CreateLimitModel, MoneyLimiter>, CreateLimitMapper>();
            services.AddTransient<IBaseMapper<MoneyLimiter, LimitModel>, LimitMapper>();
            services.AddTransient<IBaseMapper<UpdateLimitModel, MoneyLimiter>, UpdateLimitMapper>();
        }
    }
}
