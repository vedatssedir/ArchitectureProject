using Architecture.Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Architecture.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolver(this IServiceCollection services, IConfiguration configuration, ICoreModule[] modules)
        {

            foreach (var coreModule in modules)
            {
                coreModule.Load(services,configuration);
            }

            return ServiceTool.CreateService(services);
        }
    }
}
