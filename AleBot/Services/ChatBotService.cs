using AleBot.ChatObjects;
using AleBot.Constant;
using Microsoft.Bot.Builder;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AleBot.Services
{
    public class ChatBotService : IChatBotService
    {
        private readonly IRabitMQ _rabitMQ;
        public ChatBotService( IRabitMQ rabitMQ)
        {
            _rabitMQ= rabitMQ;
        }
        public async Task<HttpResponseMessage> SaveMessage(string message)
        {

            var substring= message.TrimStart('=');
            var index= substring.IndexOf('=');
            var StockCode = substring.Substring(index +1);
            var url = ChatRoomConstants.ApiUrl + ChatRoomConstants.PostMessageHeader + StockCode;
            using var client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(
                url, StockCode);
            _rabitMQ.SendMessage(StockCode + " quote is $93.42 per share");
            return response;
        }
    }
}
