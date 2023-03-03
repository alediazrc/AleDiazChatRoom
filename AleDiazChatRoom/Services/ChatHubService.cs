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
        public async Task MessagesToBot(string message)
        {
            try
            {
                var splitedMessage = message.Split(',').ToList();
                using (var fs = new FileStream(@"C:\temp\test.csv", FileMode.Create, FileAccess.ReadWrite))
                {
                    using (TextWriter tw = new StreamWriter(fs))
                    {
                        tw.Write(message);
                        tw.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                var exceptionMessage = ex.Message;
                throw;
            }
            
        }
    }
}
