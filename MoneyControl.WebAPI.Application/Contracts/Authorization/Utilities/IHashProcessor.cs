namespace MoneyControl.WebAPI.Application.Contracts.Authorization.Utilities
{
    public interface IHashProcessor
    {
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
