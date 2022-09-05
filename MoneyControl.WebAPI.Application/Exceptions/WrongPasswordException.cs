using System.Globalization;

namespace MoneyControl.WebAPI.Application.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() : base() { }

        public WrongPasswordException(string message) : base(message) { }

        public WrongPasswordException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
