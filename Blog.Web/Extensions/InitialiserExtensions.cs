namespace Blog.Web.Extensions
{
    public static class InitialiserExtensions
    {
        public static async Task InitialiseDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var migrations =
                services.GetRequiredService<Blog.Infrastructure.Databases.Migrations>();
            migrations.RunMigrations();
            var initApplication =
                services.GetRequiredService<Blog.Application.Interfaces.Common.IInitApplication>();
            await initApplication.RunInitAsync();
        }
    }
}
