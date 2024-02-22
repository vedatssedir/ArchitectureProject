using Architecture.Core;
using Architecture.Core.Aspects;
using Architecture.Core.CrossCuttingConcerns.Logging.SeriLog;
using MassTransit;

namespace Application
{
    [LogAspect(typeof(FileLogger))]
    public class SampleService :ISampleService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public SampleService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }


        public TestClass GetList(TestClass testClass)
        {
            _publishEndpoint.Publish(new TestClass() {Name = "Vedat",Surname = "Sedir",Age = 27});

            return testClass;
        }

    }
}
