using AleDiazChatRoom.ChatObjects;

namespace AleDiazChatRoom.Services
{
    public interface IChatHubService
    {
        public Task Broadcast(string username, string message);
        public Task OnConnectedAsync();
        public Task OnDisconnectedAsync(Exception e);
        public Task<List<MessageDto>> GetMessages();
        public Task<int> SaveMessage(MessageDto message);
    }
}
