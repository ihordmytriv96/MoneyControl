namespace MoneyControl.WebAPI.Application.Services.Models.AuthModels
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
    }
}
