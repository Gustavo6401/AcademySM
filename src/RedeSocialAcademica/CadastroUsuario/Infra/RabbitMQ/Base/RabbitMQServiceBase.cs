using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CadastroUsuario.Infra.RabbitMQ.Base
{
    public static class RabbitMQServiceBase
    {
        public static void SendMessageToQueue(string message, string queue)
        {
            ConnectionFactory factory = new ConnectionFactory { HostName = "localhost" };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            byte[] body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: queue,
                                 basicProperties: null,
                                 body: body);
        }

        public static string RecieveMessageFromQueue(string queue)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using IConnection connection = factory.CreateConnection();
            using IModel channel = connection.CreateModel();

            channel.QueueDeclare(queue: queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

            string message = "";

            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
            };

            channel.BasicConsume(queue: queue,
                                 autoAck: true,
                                 consumer: consumer);

            return message;
        }
    }
}
