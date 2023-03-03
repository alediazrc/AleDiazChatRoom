namespace AleDiazChatRoom.ExternalServices
{
    public interface IExternalBotService
    {
        public Task SendMessagesToBot(string message);
        public Task GetMessagesFromBot(string message);
    }
}
