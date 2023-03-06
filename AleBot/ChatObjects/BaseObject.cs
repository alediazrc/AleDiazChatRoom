using System.ComponentModel.DataAnnotations;
using System;

namespace AleBot.ChatObjects
{
    public class BaseObject
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
