using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using ProductService.API.DTOs;
using ProductService.Application.Commands;
using ProductService.Domain.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ProductService.Infraestructure.Messaging
{
    public class ProductMessageListener : IHostedService
    {
        private readonly IConnection _connection;
        private readonly RabbitMQ.Client.IModel _channel;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public ProductMessageListener(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;


            var factory = new ConnectionFactory()
            {
                Uri = new Uri($"amqp://{_configuration["RabbitMQ:UserName"]}:{_configuration["RabbitMQ:Password"]}@{_configuration["RabbitMQ:HostName"]}/"),
                DispatchConsumersAsync = false,
                ConsumerDispatchConcurrency = 1,
                /*HostName = _configuration["RabbitMQ:HostName"],
                Port = int.Parse(_configuration["RabbitMQ:Port"]),
                UserName = _configuration["RabbitMQ:UserName"],
                Password = _configuration["RabbitMQ:Password"],
                Ssl =
                {
                    ServerName = _configuration["RabbitMQ:HostName"],
                    Enabled = true
                }*/
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "product_updates",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
            
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _channel.QueueDeclare(queue: "product_updates",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var parts = message.Split(':');
                var productId = Guid.Parse(parts[0]);
                var quantity = int.Parse(parts[1]);

                var productDto = new UpdateProductDto()
                {
                    Quantity = quantity,
                };

                var command = new UpdateProductCommand(productId, productDto);

                await _mediator.Send(command);
            };

            _channel.BasicConsume(queue: "product_updates", autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Close();
            _connection.Close();
            return Task.CompletedTask;
        }
    }
}
