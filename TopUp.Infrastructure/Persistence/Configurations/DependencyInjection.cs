using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TopUp.Application.Services;
using TopUp.Domain.Interfaces;
using TopUp.Infrastructure.Persistence.Context;
using TopUp.Infrastructure.Repositories;

namespace TopUp.Infrastructure.Persistence.Configurations
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            // Register DbContext, external connections, etc. here
            services.AddDbContext<AppDbContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)),ServiceLifetime.Scoped);

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddKeyedSingleton<SMSNotification>("sms");
            services.AddKeyedSingleton<EmailNotification>("email");
            return services;
        }
    }
}
