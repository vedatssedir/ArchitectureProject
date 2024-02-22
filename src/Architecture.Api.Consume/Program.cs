using Architecture.Api.Consume;
using Architecture.Api.Consume.Consumer;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(x =>
    {
        x.RegisterModule(new AutofacBusinessModule());
    });

builder.Services.AddMassTransit(busConfigurator =>
{

    busConfigurator.AddConsumer<TestConsumer>();

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {

        configurator.Host("localhost", "/", x =>
        {
            x.Username("guest");
            x.Password("guest");
        });
        configurator.ConfigureEndpoints(context);
    });
});









// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
