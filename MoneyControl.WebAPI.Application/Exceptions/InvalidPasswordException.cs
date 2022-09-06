using System.Globalization;

namespace MoneyControl.WebAPI.Application.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base() { }

        public InvalidPasswordException(string message) : base(message) { }

        public InvalidPasswordException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
