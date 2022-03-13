using message_api.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMessageService _messageService;
        private readonly IModel _channel;

        public Worker(ILogger<Worker> logger, IMessageService messageService)
        {
            _logger = logger;
            _messageService = messageService;
            _channel = _messageService.GetChannel();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received from Rabbit: {0}", message);
            };

            _channel.BasicQos(0, 1, false);

            _channel.BasicConsume(queue: "hello",
                                    autoAck: true,
                                    consumer: consumer);

            await Task.CompletedTask;
        }
    }
}