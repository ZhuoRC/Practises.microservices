using message_api.Services;
using RabbitMQWorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IMessageService, MessageService>();
    })
    .Build();

await host.RunAsync();
