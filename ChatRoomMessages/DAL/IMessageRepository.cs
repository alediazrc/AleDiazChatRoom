using ChatRoomMessages.ChatObjects;

namespace ChatRoomMessages.DAL
{
    public interface IMessageRepository
    {
        public Task<List<Message>> GetMessages();
        public Task<int> SaveMessage(string message);
    }
}
