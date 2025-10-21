using Microsoft.EntityFrameworkCore;
using TopUp.Application.Services;
using TopUp.Infrastructure.Persistence.Context;

namespace ToUp.API.Extention
{
    public static class ServiceRegister
    {
        public static void RegisterCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowed(_ => true)
                        .AllowCredentials());
            });
        }
    }
}
