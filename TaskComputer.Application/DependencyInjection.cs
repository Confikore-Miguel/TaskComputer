
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskComputer.Application.Common.Behaviors;

namespace TaskComputer.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });
            services.AddCustomValidator();
            return services;
        }

        public static IServiceCollection AddCustomValidator(this IServiceCollection services)
        {
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>)
            );
            // ejemplo de como registrar validadores de comandos específicos
            //services.AddValidatorsFromAssembly(typeof(CreateCustomCommandValidator).Assembly);

            return services;
        }
    }
}
