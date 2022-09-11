namespace MoneyControl.WebAPI.Application.Contracts.Models.AuthModels
{
    public interface IRegisterUserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
