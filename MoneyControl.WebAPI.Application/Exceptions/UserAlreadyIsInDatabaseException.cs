using System.Globalization;

namespace MoneyControl.WebAPI.Application.Exceptions
{
    public class UserAlreadyIsInDatabaseException : Exception
    {
        public UserAlreadyIsInDatabaseException() : base() { }

        public UserAlreadyIsInDatabaseException(string message) : base(message) { }

        public UserAlreadyIsInDatabaseException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
