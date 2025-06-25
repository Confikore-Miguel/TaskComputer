
using Microsoft.Extensions.DependencyInjection;

namespace TaskComputer.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });
            return services;
        }
    }
}
