using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Mappers;
using MoneyControl.WebAPI.Host.Mappers.ExpencesMappers;
using MoneyControl.WebAPI.Host.Mappers.ExpencesTypeMappers;
using MoneyControl.WebAPI.Host.Mappers.ExpensesMappers;
using MoneyControl.WebAPI.Host.Mappers.ExpensesTypeMappers;
using MoneyControl.WebAPI.Host.Mappers.UserMappers;
using MoneyControl.WebAPI.Host.Models.ExpensesModels;
using MoneyControl.WebAPI.Host.Models.ExpensesTypeModels;
using MoneyControl.WebAPI.Host.Models.UserModels;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class MapperRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IBaseMapper<ExpensesTypeModel, ExpensesType>, ExpensesTypeMapper>();
            services.AddTransient<IBaseMapper<CreateExpensesModel, Expenses>, CreateExpensesMapper>();
            services.AddTransient<IBaseMapper<ExpensesType, ExpensesTypeModel>, ExpensesTypeModelMapper>();
            services.AddTransient<IBaseMapper<User, UserNameModel>, UserNameMapper>();
            services.AddTransient<IBaseMapper<Expenses, ExpensesModel>, ExpensesModelMapper > ();
        }
    }
}
