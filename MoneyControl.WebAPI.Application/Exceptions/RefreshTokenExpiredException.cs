using System.Globalization;

namespace MoneyControl.WebAPI.Application.Exceptions
{
    public class RefreshTokenExpiredException : Exception
    {
        public RefreshTokenExpiredException() : base() { }

        public RefreshTokenExpiredException(string message) : base(message) { }

        public RefreshTokenExpiredException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
