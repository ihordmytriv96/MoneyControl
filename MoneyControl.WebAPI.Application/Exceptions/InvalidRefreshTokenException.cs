using System.Globalization;

namespace MoneyControl.WebAPI.Application.Exceptions
{
    public class InvalidRefreshTokenException : Exception
    {
        public InvalidRefreshTokenException() : base() { }

        public InvalidRefreshTokenException(string message) : base(message) { }

        public InvalidRefreshTokenException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
