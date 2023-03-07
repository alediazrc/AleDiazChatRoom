using AleDiazChatRoom.Constant;

namespace AleDiazChatRoom.ExternalServices
{
    public class ExternalBotService : IExternalBotService
    {
        public Task GetMessagesFromBot(string message)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> SendMessagesToBot(string message)
        {
            try
            {
                message = message.Substring(message.IndexOf("=")+1);
                var csv = ChatRoomConstants.BaseCsvUrl + message + ChatRoomConstants.HeaderCsvUrl;
                var url = ChatRoomConstants.BotUrl + csv;
                using var client = new HttpClient();
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    url, csv);
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
