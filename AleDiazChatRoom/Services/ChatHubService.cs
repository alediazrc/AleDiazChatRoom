using System;
using System.Text;
using System.Threading.Tasks;
using AleDiazChatRoom.ChatObjects;
using AleDiazChatRoom.DAL;
using AleDiazChatRoom.ExternalServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;

namespace AleDiazChatRoom.Services
{
    public class ChatHubService : Hub, IChatHubService, IBotService
    {
        [Inject]
        private IMessageRepository messageRepository{get;set;}
        private IExternalBotService botService{get;set;}
        public ChatHubService(IMessageRepository messageRepository, IExternalBotService externalBotService)
        {
            this.messageRepository = messageRepository;
            this.botService = externalBotService;
        }

        public async Task Broadcast(string username, string message)
        {
            await Clients.All.SendAsync("Broadcast", username, message);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }
        public async Task<string> SendMessagesToBot(string message)
        {
            try
            {
                return await botService.SendMessagesToBot(message);
            }
            catch (Exception ex)
            {
                var exceptionMessage = ex.Message;
                throw;
            }
            
        }
        public async Task GetMessagesFromBot(string message)
        {

        }

        public async Task<List<MessageDto>> GetMessages()
        {
            try
            {
                var response = await messageRepository.GetMessages();
                return response;
            }
            catch (Exception)
            {
                return new List<MessageDto>();
            }
            
        }

        public async Task<int> SaveMessage(MessageDto message)
        {
            try
            {
                var response = await messageRepository.SaveMessage(message);
                return response;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
    }
}
