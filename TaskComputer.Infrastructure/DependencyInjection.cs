using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskComputer.Application.Data;
using TaskComputer.Domain.Interfaces;
using TaskComputer.Domain.Primitives;
using TaskComputer.Infrastructure.Persistence;
using TaskComputer.Infrastructure.Providers.Tenant;
using TaskComputer.Infrastructure.Repositories;

namespace TaskComputer.Infrastructure
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<ITenantProvider, TenantProvider>();

            services.AddDbContext<TaskComputerContext>((serviceProvider, options) =>
            {
                var tenantProvider = serviceProvider.GetRequiredService<ITenantProvider>();
                var connectionString = tenantProvider.GetTenantConnectionString();
                options.UseSqlServer(connectionString);
            });
       
            services.AddScoped<ITaskComputerDbContext>(sp => sp.GetRequiredService<TaskComputerContext>());
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TaskComputerContext>());
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
