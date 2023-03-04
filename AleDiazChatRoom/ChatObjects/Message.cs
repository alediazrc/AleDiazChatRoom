﻿namespace AleDiazChatRoom.ChatObjects
{
    public class Message : BaseObject
    {
        public Message(string username, string body, bool mine)
        {
            Username = username;
            Body = body;
            Mine = mine;
        }
        
        public string Username { get; set; }
        public string Body { get; set; }
        public bool Mine { get; set; }
    }
}
