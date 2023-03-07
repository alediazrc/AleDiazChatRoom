using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AleBot.Services
{
    public class RabitMQ : IRabitMQ
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnection();
            using
            var channel = connection.CreateModel();
            channel.QueueDeclare("ChatMessage", exclusive: false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "ChatMessage", body: body);

        }
    }
}
