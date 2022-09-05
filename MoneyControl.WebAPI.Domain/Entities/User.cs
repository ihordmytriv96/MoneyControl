using MoneyControl.WebAPI.Domain.Entities.Base;

namespace MoneyControl.WebAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
