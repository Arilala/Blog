using Blog.Application.Interfaces.Repository;
using Blog.Application.Interfaces.SqlFactory;
using Blog.Infrastructure.Databases;
using Blog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtension
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddServiceInfrastructure(string connectionString)
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string not found.");
                }
                services.AddScoped<ISqlConnectionFactory>(_ => new SqlConnectionFactory(
                    connectionString
                ));
                services.AddScoped<Migrations>();
                services.AddSingleton<ISqlQueryProvider, SqlQueryProvider>();
                //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IRoleRepository, RoleRepository>();
                return services;
            }
        }
    }
}
