using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Mappers;
using MoneyControl.WebAPI.Host.Mappers.ExpencesTypeMappers;
using MoneyControl.WebAPI.Host.Models.ExpencesTypeModels;

namespace MoneyControl.WebAPI.Host.Config.Dependencies.AllDependencies
{
    public static class MapperRegisterDependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IBaseMapper<ExpencesTypeModel, ExpencesType>, ExpencesTypeMapper>();
        }
    }
}
