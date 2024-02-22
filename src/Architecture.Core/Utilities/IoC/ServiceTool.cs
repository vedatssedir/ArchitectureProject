using Microsoft.Extensions.DependencyInjection;

namespace Architecture.Core.Utilities.IoC;

public static class ServiceTool
{
    public static IServiceProvider? ServiceProvider { get; set; }

    public static IServiceCollection CreateService(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}