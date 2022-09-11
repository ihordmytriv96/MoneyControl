namespace MoneyControl.WebAPI.Application.Contracts.Models.AuthModels
{
    public interface ILoginUserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
