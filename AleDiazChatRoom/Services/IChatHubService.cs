namespace AleDiazChatRoom.Services
{
    public interface IChatHubService
    {
        public Task Broadcast(string username, string message);
        public Task OnConnectedAsync();
        public Task OnDisconnectedAsync(Exception e);

    }
}
