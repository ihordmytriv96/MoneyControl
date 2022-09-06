using MoneyControl.WebAPI.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace MoneyControl.WebAPI.Host.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case WrongPasswordException e:
                    case UserNotFoundException u:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case InvalidRefreshTokenException e:
                    case RefreshTokenExpiredException u:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case InvalidLoginException log:
                    case InvalidPasswordException pas:
                    case UserAlreadyIsInDatabaseException already:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
