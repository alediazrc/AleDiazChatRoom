namespace AleDiazChatRoom.ExternalServices
{
    public class ExternalBotService : IExternalBotService
    {
        public Task GetMessagesFromBot(string message)
        {
            throw new NotImplementedException();
        }

        public Task SendMessagesToBot(string message)
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
            return Task.CompletedTask;
        }
    }
}
