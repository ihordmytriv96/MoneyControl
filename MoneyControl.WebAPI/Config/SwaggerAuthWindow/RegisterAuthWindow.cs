using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace MoneyControl.WebAPI.Host.Config.SwaggerAuthWindow
{
    public static class RegisterAuthWindow
    {
        public static void RegisterWindow(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    Description = "Standart Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                ((IConfiguration)provider.GetService(typeof(IConfiguration))).GetSection("AppSettings:Token").Value)
                            ),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
    }
}
