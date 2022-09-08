using MoneyControl.WebAPI.Application.Contracts.Validations;
using MoneyControl.WebAPI.Application.Services.Models.AuthModels;
using MoneyControl.WebAPI.Domain.Contracts.Repositories;

namespace MoneyControl.WebAPI.Application.Services.Validations
{
    public class UserValidationManager : IBaseValidator<UserModel>
    {
        private readonly IUserRepository _userRepository;

        public UserValidationManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<string>> IsValidAsync(UserModel user, CancellationToken token)
        {
            var login = string.IsNullOrEmpty(user.Login);
            var password = string.IsNullOrEmpty(user.Password);
            var firstName = string.IsNullOrEmpty(user.FirstName);
            var lastName = string.IsNullOrEmpty(user.LastName);

            var userIsInDatabase = await _userRepository.FindOneAsync(x => x.Login == user.Login, token) != null;
            var errorList = new List<string>();

            if (login && (user.Login.Length < 5 || user.Login.Length > 15))
            {
                errorList.Add("Login must have min 5 max 15 symbols");
            }
            else if (password && (user.Password.Length < 5 || user.Password.Length > 10))
            {
                errorList.Add("Password must have min 5 max 10 symbols");
            }
            else if (userIsInDatabase)
            {
                errorList.Add("User already exist");
            }
            else if (firstName && (user.FirstName.Length < 2 || user.FirstName.Length > 10))
            {
                errorList.Add("First name must have min 2 max 10 symbols");
            } 
            else if (lastName && user.LastName.Length < 2 || user.LastName.Length > 15)
            {
                errorList.Add("Last name must have min 2 max 15 symbols");
            }

            return errorList;
        }

    }
}
