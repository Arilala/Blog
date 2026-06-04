using Blog.Application.Interfaces.Security;
using Blog.Application.Services.Security;
using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blog.Application.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            var assemblies = Assembly.GetExecutingAssembly();
            // var currentAssembly = typeof(ApplicationServiceExtension).Assembly;
            services.AddLiteBus(liteBus =>
            {
                liteBus.AddCommandModule(module =>
                {
                    module.RegisterFromAssembly(assemblies);
                });
                liteBus.AddQueryModule(module =>
                {
                    module.RegisterFromAssembly(assemblies);
                });
            });

            services.AddScoped<IPasswordService, PasswordService>();
            return services;
        }
    }
}
