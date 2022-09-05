using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.ExpencesTypeModels;

namespace MoneyControl.WebAPI.Host.Mappers.ExpencesTypeMappers
{
    public class ExpencesTypeMapper : IBaseMapper<ExpencesTypeModel, ExpencesType>
    {
        public ExpencesType Map(ExpencesTypeModel map)
        => new ExpencesType()
        {
            TypeName = map.TypeName
        };
    }
}
