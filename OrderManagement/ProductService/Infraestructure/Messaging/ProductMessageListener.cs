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
    public class ProductMessageListener
    {
        private readonly IConnection _connection;
        private readonly RabbitMQ.Client.IModel _channel;
        private readonly IMediator _mediator;
        public ProductMessageListener(IMediator mediator)
        {
            _mediator = mediator;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "product_updates",
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);
        }

        public void StartListening ()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var parts = message.Split(":");
                var Id = Guid.Parse(parts[0]);
                var quantity = int.Parse(parts[1]);

                var productDto = new UpdateProductDto()
                {
                    Quantity = quantity,
                };

                var command = new UpdateProductCommand(Id, productDto);

                await _mediator.Send(command);
            };

            _channel.BasicConsume(queue: "product_updates", autoAck: true, consumer: consumer);
        }
    }
}
