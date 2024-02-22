using Architecture.Api.Consume.Consumer;
using Architecture.Core;
using Architecture.Core.Aspects;
using Architecture.Core.CrossCuttingConcerns.Logging.SeriLog;
using Architecture.Core.Utilities.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using MassTransit;

namespace Architecture.Api.Consume
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterGeneric(typeof(TestConsumer))
                .As(typeof(IConsumer<TestClass>))
                .InstancePerLifetimeScope();

            //builder.RegisterType<TestConsumer>().As<IConsumer<TestClass>>().SingleInstance();
            //builder.RegisterType<LogAspect>();
            //builder.RegisterType<FileLogger>();


            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
