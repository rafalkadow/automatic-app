using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Application.Common.Behaviors;
using FluentValidation;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Extensions
{
    public static class IfrastructureExtensions
    {
        public static IServiceCollection AddIfrastructure(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddMediatR(cf =>
            {
                cf.RegisterServicesFromAssembly(typeof(IfrastructureExtensions).Assembly);
                cf.Lifetime = ServiceLifetime.Scoped;
            });
            return services;
        }
    }
}