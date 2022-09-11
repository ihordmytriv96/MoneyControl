using MoneyControl.WebAPI.Application.Contracts.Models.AuthModels;
using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.UserModels
{
    public class RegisterUserModel : IRegisterUserModel
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
    }
}
