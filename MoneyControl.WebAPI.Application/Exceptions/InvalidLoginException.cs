using System.Globalization;

namespace MoneyControl.WebAPI.Application.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException() : base() { }

        public InvalidLoginException(string message) : base(message) { }

        public InvalidLoginException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
