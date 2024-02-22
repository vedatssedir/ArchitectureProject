using Architecture.Core.Utilities.IoC;
using Architecture.Core.Utilities.MessageBrokers.RabbitMq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Architecture.Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddSingleton(typeof(IRabbitMqService<>), typeof(RabbitMqService<>));
        }
    }
}
