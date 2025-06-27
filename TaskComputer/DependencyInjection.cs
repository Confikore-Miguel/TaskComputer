using TaskComputer.Middlewares;

namespace TaskComputer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<GlobalExeptionHandlingMiddleware>();
            return services;
        }
    }
}
