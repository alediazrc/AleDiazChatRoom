using System.ComponentModel.DataAnnotations;

namespace ChatRoomMessages.ChatObjects
{
    public class BaseObject
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
