using System.ComponentModel.DataAnnotations;

namespace AleDiazChatRoom.ChatObjects
{
    public class BaseObject
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
