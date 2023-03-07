namespace AleBot.Services
{
    public interface IRabitMQ
    {
        public void SendMessage<T>(T message);

    }
}
