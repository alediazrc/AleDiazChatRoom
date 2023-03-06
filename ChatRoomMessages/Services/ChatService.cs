using ChatRoomMessages.ChatObjects;
using ChatRoomMessages.DAL;
using Microsoft.AspNetCore.Components;

namespace ChatRoomMessages.Services
{
    public class ChatService : IChatService
    {
        public IMessageRepository messageRepository { get; set; }
        public async Task<List<Message>> GetMessages()
        {
            try
            {
                var response = await messageRepository.GetMessages();
                return response;
            }
            catch (Exception)
            {
                return new List<Message>();
            }
        }

        public async Task<int> SaveMessage(Message message)
        {
            var response = await messageRepository.SaveMessage(message);
            return response;

        }
    }
}
