using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TopUp.Application.Common.CustomMediator;
using TopUp.Application.Interfaces;
using TopUp.Application.Services;


namespace TopUp.Application.Configuration
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Resolve handler dependency for our custom mediator
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register all IRequestHandler implementations automatically
            var assembly = Assembly.GetExecutingAssembly();

            var handlerTypes = assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType &&
                                i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
                    .Select(i => new { Interface = i, Implementation = t }));

            foreach (var h in handlerTypes)
            {
                services.AddScoped(h.Interface, h.Implementation);
            }

            // Register custom mediator itself
            services.AddScoped<IMediator, Mediator>();

            //topup
            services.AddScoped<ITopUpServices, TopUpServices>();

            return services;
        }
    }
}
