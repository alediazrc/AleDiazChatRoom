namespace AleBot.ChatObjects
{
    public class Message : BaseObject
    {
        public Message(string username, string body, bool mine)
        {
            Username = username;
            Body = body;
            Mine = mine;
        }
        public Message()
        {

        }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Body { get; set; }
        public bool Mine { get; set; }
        public bool IsCommand { get; set; }
    }
}
