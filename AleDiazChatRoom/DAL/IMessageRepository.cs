using AleDiazChatRoom.ChatObjects;

namespace AleDiazChatRoom.DAL
{
    public interface IMessageRepository
    {
        public Task<List<MessageDto>> GetMessages();
        public Task<int> SaveMessage(MessageDto message);
    }
}
