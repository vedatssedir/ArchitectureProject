namespace Architecture.Core.Utilities.MessageBrokers.RabbitMq.Models;

public class RabbitMqSettings
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Host { get; set; }
    public string? VirtualHost { get; set; }
}