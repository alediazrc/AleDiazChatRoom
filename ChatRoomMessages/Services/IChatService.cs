using ChatRoomMessages.ChatObjects;

namespace ChatRoomMessages.Services
{
    public interface IChatService
    {
        public Task<List<Message>> GetMessages();
        public Task<int> SaveMessage(string StockCode);
    }
}
