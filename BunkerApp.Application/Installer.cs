using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BunkerApp.Application;

public static class Installer
{
    public static IServiceCollection InstallApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}