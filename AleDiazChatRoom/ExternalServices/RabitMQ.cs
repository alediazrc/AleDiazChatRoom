using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace AleDiazChatRoom.ExternalServices
{
    public class RabitMQ : IRabitMQ
    {
        private string messageRecieved = string.Empty;
        public string GetMessages()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using
            var channel = connection.CreateModel();
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare("product", exclusive: false);
            //Set Event object which listen message from chanel which is sent by producer
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                messageRecieved = Encoding.UTF8.GetString(body);

            };
            return messageRecieved;
        }
    }
}
