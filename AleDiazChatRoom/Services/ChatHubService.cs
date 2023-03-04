using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AleDiazChatRoom.Services
{
    public class ChatHubService : Hub, IChatHubService, IBotService
    {
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
        public async Task SendMessagesToBot(string message)
        {
            try
            {
                
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
    }
}
