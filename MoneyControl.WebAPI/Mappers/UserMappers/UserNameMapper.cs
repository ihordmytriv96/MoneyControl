using MoneyControl.WebAPI.Domain.Entities;
using MoneyControl.WebAPI.Host.Models.UserModels;
using MongoDB.Driver;

namespace MoneyControl.WebAPI.Host.Mappers.UserMappers
{
    public class UserNameMapper : IBaseMapper<User, UserNameModel>
    {
        public UserNameModel Map(User map)
        => new UserNameModel()
        {
            FirstName = map.FirstName,
            LastName = map.LastName
        };
    }
}
