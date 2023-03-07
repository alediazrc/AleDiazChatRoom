namespace AleDiazChatRoom.ExternalServices
{
    public interface IExternalBotService
    {
        public Task<HttpResponseMessage> SendMessagesToBot(string message);
        public Task GetMessagesFromBot(string message);
    }
}
