using MoneyControl.WebAPI.Application.Contracts.Models.AuthModels;
using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.UserModels
{
    public class LoginUserModel : ILoginUserModel
    {
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
