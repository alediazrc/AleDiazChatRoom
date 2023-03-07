using AleDiazChatRoom.Constant;

namespace AleDiazChatRoom.ExternalServices
{
    public class ExternalBotService : IExternalBotService
    {
        private IRabitMQ rabitMQ { get; set; }
        public ExternalBotService(IRabitMQ rabitMQ)
        {
            this.rabitMQ = rabitMQ;
        }

        public Task GetMessagesFromBot(string message)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SendMessagesToBot(string message)
        {
            try
            {
                message = message.Substring(message.IndexOf("=")+1);
                var csv = ChatRoomConstants.BaseCsvUrl + message + ChatRoomConstants.HeaderCsvUrl;
                var url = ChatRoomConstants.BotUrl + csv;
                using var client = new HttpClient();
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    url, csv);
                
                return rabitMQ.GetMessages();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
