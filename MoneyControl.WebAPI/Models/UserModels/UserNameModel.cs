using Newtonsoft.Json;

namespace MoneyControl.WebAPI.Host.Models.UserModels
{
    public class UserNameModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}
