namespace AleDiazChatRoom.Services
{
    public interface IBotService
    {
        public Task<string> SendMessagesToBot(string message);
        public Task GetMessagesFromBot(string message);

    }
}
