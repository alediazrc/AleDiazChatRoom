namespace AleDiazChatRoom.Services
{
    public interface IBotService
    {
        public Task SendMessagesToBot(string message);
        public Task GetMessagesFromBot(string message);

    }
}
