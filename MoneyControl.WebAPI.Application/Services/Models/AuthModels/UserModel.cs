namespace MoneyControl.WebAPI.Application.Services.Models.AuthModels
{
    public class UserModel
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}
