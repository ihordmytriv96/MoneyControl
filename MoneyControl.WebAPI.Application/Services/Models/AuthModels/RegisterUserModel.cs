namespace MoneyControl.WebAPI.Application.Services.Models.AuthModels
{
    public class RegisterUserModel
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } 
    }
}
