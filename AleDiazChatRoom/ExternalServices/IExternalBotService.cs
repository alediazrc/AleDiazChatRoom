namespace AleDiazChatRoom.ExternalServices
{
    public interface IExternalBotService
    {
        public Task<string> SendMessagesToBot(string message);
        public Task GetMessagesFromBot(string message);
    }
}
