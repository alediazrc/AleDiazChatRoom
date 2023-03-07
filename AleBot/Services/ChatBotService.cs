using AleBot.ChatObjects;
using AleBot.Constant;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AleBot.Services
{
    public class ChatBotService : IChatBotService
    {
        public async Task<int> SaveMessage(string message)
        {

            var substring= message.TrimStart('=');
            var index= substring.IndexOf('=');
            var StockCode = substring.Substring(index +1);
            var url = ChatRoomConstants.ApiUrl + ChatRoomConstants.PostMessageHeader + StockCode;
            using var client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(
                url, StockCode);
            var messageREsponse = response.Content.ReadAsStringAsync();
            return 1;
        }
    }
}
