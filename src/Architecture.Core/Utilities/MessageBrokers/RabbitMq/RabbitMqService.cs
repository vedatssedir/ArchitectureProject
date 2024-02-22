using MassTransit;
using MassTransit.Transports.Fabric;
using Polly;

namespace Architecture.Core.Utilities.MessageBrokers.RabbitMq;

public class RabbitMqService<T>(IBus bus) : IRabbitMqService<T> where T : class
{
    private IBus Bus { get; } = bus;


    public async Task SendEndPointQueue(T model, string queueName)
    {
        var policy =Policy.Handle<Exception>()
            .Or<TimeoutException>()
            .Or<EndpointException>()
            .Or<ConnectionException>()
            .WaitAndRetryAsync(retryCount:3, sleepDurationProvider:retryAttempt=> TimeSpan.FromSeconds(Math.Pow(2,retryAttempt)));


        await policy.ExecuteAsync(async () =>
        {
            var sendEndPoint = await Bus.GetSendEndpoint(new Uri($"queue:{queueName}?type=direct"));
            var timeOut = TimeSpan.FromSeconds(30);
            using var source = new CancellationTokenSource(timeOut);
            await sendEndPoint.Send(model, source.Token);
        });
    }
}