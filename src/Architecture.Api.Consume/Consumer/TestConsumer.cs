using Architecture.Core;
using Architecture.Core.Aspects;
using Architecture.Core.CrossCuttingConcerns.Logging.SeriLog;
using MassTransit;

namespace Architecture.Api.Consume.Consumer
{
   
    public class TestConsumer :IConsumer<TestClass>
    {
        [LogAspect(typeof(FileLogger))]
        public Task Consume(ConsumeContext<TestClass> context)
        {

            return Task.CompletedTask;
        }
    }
}
