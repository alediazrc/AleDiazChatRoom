using AleDiazChatRoom.ChatObjects;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AleDiazChatRoom.DAL
{
    public class ChatRoomProfile : Profile
    {
        public ChatRoomProfile()
        {
            CreateMap<MessageDto, Message>();
            CreateMap<Message, MessageDto>();
        }
    }
}
