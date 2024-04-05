using Application.Utilities;
using Domain.Interfaces;
using Domain.Modules.Base.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceCollection
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddTransient<IDefinitionModel, DefinitionModel>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}