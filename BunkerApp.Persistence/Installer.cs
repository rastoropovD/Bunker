using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BunkerApp.Persistence;

public static class Installer
{
    public static IServiceCollection InstallDb(this IServiceCollection services, string connectionString)
    {
        services
            .AddScoped<DbContext, BunkerDbContext>();
        services.AddDbContext<BunkerDbContext>(options => options.UseNpgsql(connectionString));
            
        return services;
    }
}