using RabbitMQ.Client;
using System.Text;

namespace OrderService.Infraestructure.Messaging
{
    public class ProductMessageSender
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public ProductMessageSender()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "123456",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "product_updates",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public void SendProductUpdateMessage (Guid productId, int quantity)
        {
            var message = $"{productId}:{quantity}";

            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "", routingKey: "product_updates", basicProperties: null, body: body);
        }
    }
}
