namespace ChatRoomMessages.Models
{
    public class Message
    {
        public string Symbol { get; set; }
        public DateTime MessageDate { get; set; }
        public DateTime MessageTime { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Volume { get; set; }
     
    }
}
